using ReportingService.DataCreator.Models;
using System;

namespace ReportingService.DataCreator;

public class Reader
{
    public void ConvertToCsv(List<IModel> listModels, string filename)
    {
        using (var file = new StreamWriter(filename))
        {
            foreach (var item in listModels)
            {
                file.WriteLine(item.ToCsvRow());
            }
        }
    }

    public List<IModel> GetLeads(string filename)
    {
        string line;
        var leads = new List<IModel>();

        using (StreamReader sr = new StreamReader(filename))
        {
            while ((line = sr.ReadLine()) != null)
            {
                var lead = new Lead(line);
                leads.Add(lead);
            }
        }
        return leads;
    }

    public List<IModel> GetAccounts(string filename)
    {
        string line;
        var accounts = new List<IModel>();

        using (StreamReader sr = new StreamReader(filename))
        {
            while ((line = sr.ReadLine()) != null)
            {
                var account = new Account(line);
                accounts.Add(account);
            }
        }
        return accounts;
    }

    public List<IModel> GetTransactions(string filename)
    {
        string line;
        var transactions = new List<IModel>();

        using (StreamReader sr = new StreamReader(filename))
        {
            int index = 0;
            while ((line = sr.ReadLine()) != null)
            {
                //if (index <= 2)
                //    index++;
                //else
                //{
                    var transaction = new TransactionFromCsv(line);
                    transactions.Add(transaction);
                    index++;
                //}
            }
        }
        return transactions;
    }

    public List<int> GetAccountsId(string filename)
    {
        string line;
        var accountIds = new List<int>();
        using (StreamReader sr = new StreamReader(filename))
        {
            while ((line = sr.ReadLine()) != null)
            {
                var account = new Account(line);
                accountIds.Add(account.LeadId);
            }
        }
        return accountIds.Distinct().ToList(); ;
    }
}