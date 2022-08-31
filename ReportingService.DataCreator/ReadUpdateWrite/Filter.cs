using ReportingService.DataCreator.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Reflection;

namespace ReportingService.DataCreator;

public class Filter
{
    private  Reader _reader;

    [SetUp]
    public void Setup()
    {
        _reader = new Reader();
    }

    //[Test]
    public async Task ReadLeads()
    {
        var leads = _reader.GetLeads(@"D:\Курсы\С#\Lead.csv");
        leads = leads.Where(x => x.LeadId < 1800000 || x.LeadId > 4500000).ToList();
        _reader.ConvertToCsv(leads, @"D:\Курсы\С#\LeadFiltered.csv");
    }

    //[Test]
    public async Task ReadAccounts()
    {
        var accounts = _reader.GetAccounts(@"D:\Курсы\С#\Account.csv");
        accounts = accounts.Where(x => x.LeadId < 1800000 || x.LeadId > 4500000).ToList();
        _reader.ConvertToCsv(accounts, @"D:\Курсы\С#\AccountFiltered.csv");
    }

    //[Test]
    public async Task ReadTransaction()
    {
        var transactions = _reader.GetTransactions(@"D:\Курсы\С#\Transaction2.csv");
        var accountsId = _reader.GetAccountsId(@"D:\Курсы\С#\AccountFiltered.csv");

        var hash = new HashSet<int>(accountsId);
        transactions = transactions.Where(x => hash.Contains(x.AccountId)).ToList();

        _reader.ConvertToCsv(transactions, @"D:\Курсы\С#\TransactionFiltered.csv");

    }

    [Test]
    public void ModifyTransactions()
    {
        var transactions = _reader.GetTransactions(@"D:\Курсы\С#\TransactionFiltered.csv");
        var transactionsModified = RebuildTransactions(transactions);
        _reader.ConvertToCsv(transactionsModified, @"D:\Курсы\С#\TransactionModified.csv");
    }


    public List<IModel> RebuildTransactions(List<IModel> transactions)
    {
        List<IModel> newTransactions = new List<IModel>();
        var transactionsDictionary = transactions.GroupBy(a => a.Date).ToDictionary(d => d.Key, d => d.ToList());
        foreach (var (key, value) in transactionsDictionary)
        {
            if (value.Count == 2)
            {
                var sender = value.Where(x => x.Amount < 0) as TransactionFromCsv;
                var recipient = value.Where(x => x.Amount > 0) as TransactionFromCsv;
                var newTransaction = new TransactionToDb(sender, recipient);
                newTransactions.Add(newTransaction);
                //TransferConstructor
            }
            else
            {
                var sender = value[0] as TransactionFromCsv;
                var newTransaction = new TransactionToDb(sender);
                newTransactions.Add(newTransaction);
                //Ordinary constructor
            }
        }
        return newTransactions;
    }

}
