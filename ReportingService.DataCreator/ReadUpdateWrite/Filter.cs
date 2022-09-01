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
        _reader.ConvertToCsv(leads, @"D:\Курсы\С#\LeadFiltered.csv");
    }

    //[Test]
    public async Task ReadAccounts()
    {
        var accounts = _reader.GetAccounts(@"D:\Курсы\С#\Account.csv");
        _reader.ConvertToCsv(accounts, @"D:\Курсы\С#\AccountFiltered.csv");
    }

    //[Test]
    public async Task ReadTransaction()
    {
        var transactions = _reader.GetTransactions(@"D:\Курсы\С#\Transaction.csv");
        _reader.ConvertToCsv(transactions, @"D:\Курсы\С#\TransactionFiltered.csv");
    }

    //[Test]
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
        int i = 0;
        foreach (var (key, value) in transactionsDictionary)
        {
            var first = value.Find(x => x.Amount < 0 && x.TransactionType == 3) as TransactionFromCsv;
            if (first != null && value.Count == 2)
            {
                value.Remove(first);
                value.Insert(0, first);
                var a = value[0] as TransactionFromCsv;
                var b = value[1] as TransactionFromCsv;
                if (a.TransactionType == 3 && b.Amount > 0)
                {
                    var sender = value.Find(x => x.Amount < 0) as TransactionFromCsv;
                    var recipient = value.Find(x => x.Amount > 0) as TransactionFromCsv;
                    var newTransaction = new TransactionToDb(sender, recipient);
                    newTransactions.Add(newTransaction);
                    //TransferConstructor
                }
            }
            else
            {
                var k = value[0] as TransactionFromCsv;
                if (k.TransactionType != 3)
                {
                    newTransactions.Add(k);
                }
                //Ordinary constructor
            }
        }
        return newTransactions;
    }

}
