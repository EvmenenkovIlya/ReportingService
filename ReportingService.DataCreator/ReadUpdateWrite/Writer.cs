using ReportingService.DataCreator.Models;
using System.Data.SqlClient;
using System.Data;
namespace ReportingService.DataCreator.ReadUpdateWrite;

public class Writer
{
    private Reader _reader;

    [SetUp]
    public void Setup()
    {
        _reader = new Reader();
    }

    //[Test]
    public void BulkInsertLeads()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(int)));
        tbl.Columns.Add(new DataColumn("LeadId", typeof(int)));
        tbl.Columns.Add(new DataColumn("FirstName", typeof(string)));
        tbl.Columns.Add(new DataColumn("LastName", typeof(string)));
        tbl.Columns.Add(new DataColumn("Patronymic", typeof(string)));
        tbl.Columns.Add(new DataColumn("BirthDate", typeof(DateTime)));
        tbl.Columns.Add(new DataColumn("Email", typeof(string)));
        tbl.Columns.Add(new DataColumn("Phone", typeof(string)));
        tbl.Columns.Add(new DataColumn("Passport", typeof(string)));
        tbl.Columns.Add(new DataColumn("City", typeof(short)));
        tbl.Columns.Add(new DataColumn("Address", typeof(string)));
        tbl.Columns.Add(new DataColumn("Role", typeof(short)));
        tbl.Columns.Add(new DataColumn("RegistrationDate", typeof(DateTime)));
        tbl.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

        var leads = _reader.GetLeads(@"FilePath");
        for (int i = 1600000; i < leads.Count; i++)
        {
            var lead = (Lead)leads[i];
            DataRow dr = tbl.NewRow();
            dr["Id"] = i + 1;
            dr["LeadId"] = lead.LeadId;
            dr["FirstName"] = lead.FirstName;
            dr["LastName"] = lead.LastName;
            dr["Patronymic"] = lead.Patronymic;
            dr["BirthDate"] = lead.BirthDate;
            dr["Email"] = lead.Email;
            dr["Phone"] = lead.Phone;
            dr["Passport"] = lead.Passport;
            dr["City"] = lead.City;
            dr["Address"] = lead.Address;
            dr["Role"] = lead.Role;
            var rg = lead.RegistrationDate.AddYears(20);
            dr["RegistrationDate"] = rg;
            dr["IsDeleted"] = lead.IsDeleted;
            tbl.Rows.Add(dr);
        }

        string connection = @"ConnectionString";
        SqlConnection con = new SqlConnection(connection);
        SqlBulkCopy objbulk = new SqlBulkCopy(con);

        objbulk.DestinationTableName = "[ReportingService.DB].[dbo].[LeadInfo]";
        objbulk.ColumnMappings.Add("Id", "Id");
        objbulk.ColumnMappings.Add("LeadId", "LeadId");
        objbulk.ColumnMappings.Add("FirstName", "FirstName");
        objbulk.ColumnMappings.Add("LastName", "LastName");
        objbulk.ColumnMappings.Add("Patronymic", "Patronymic");
        objbulk.ColumnMappings.Add("BirthDate", "BirthDate");
        objbulk.ColumnMappings.Add("Email", "Email");
        objbulk.ColumnMappings.Add("Phone", "Phone");
        objbulk.ColumnMappings.Add("Passport", "Passport");
        objbulk.ColumnMappings.Add("City", "City");
        objbulk.ColumnMappings.Add("Address", "Address");
        objbulk.ColumnMappings.Add("Role", "Role");
        objbulk.ColumnMappings.Add("RegistrationDate", "RegistrationDate");
        objbulk.ColumnMappings.Add("IsDeleted", "IsDeleted");

        con.Open();
        objbulk.WriteToServer(tbl);
        con.Close();
    }

    [Test]
    public void BulkInsertAccounts()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(int)));
        tbl.Columns.Add(new DataColumn("AccountId", typeof(int)));
        tbl.Columns.Add(new DataColumn("Currency", typeof(int)));
        tbl.Columns.Add(new DataColumn("Status", typeof(int)));
        tbl.Columns.Add(new DataColumn("LeadId", typeof(int)));


        var accounts = _reader.GetAccounts((@"FilePath"));
        for (int i = 0; i < accounts.Count; i++)
        {
            var account = (Account)accounts[i];
            DataRow dr = tbl.NewRow();
            dr["Id"] = i + 1;
            dr["AccountId"] = account.AccountId;
            dr["Currency"] = account.Currency;
            dr["Status"] = account.Status;
            dr["LeadId"] = account.LeadId;
            tbl.Rows.Add(dr);
        }

        string connection = @"ConnectionString";
        SqlConnection con = new SqlConnection(connection);
        SqlBulkCopy objbulk = new SqlBulkCopy(con);

        objbulk.DestinationTableName = "[ReportingService.DB].[dbo].[Account]";
        objbulk.ColumnMappings.Add("Id", "Id");
        objbulk.ColumnMappings.Add("AccountId", "AccountId");
        objbulk.ColumnMappings.Add("Currency", "Currency");
        objbulk.ColumnMappings.Add("Status", "Status");
        objbulk.ColumnMappings.Add("LeadId", "LeadId");

        con.Open();
        objbulk.WriteToServer(tbl);
        con.Close();
    }

    //[Test]
    public void BulkInsertTransactions()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(int)));
        tbl.Columns.Add(new DataColumn("TransactionId", typeof(long)));
        tbl.Columns.Add(new DataColumn("AccountId", typeof(long)));
        tbl.Columns.Add(new DataColumn("Date", typeof(DateTime)));
        tbl.Columns.Add(new DataColumn("TransactionType", typeof(byte)));
        tbl.Columns.Add(new DataColumn("Amount", typeof(decimal)));
        tbl.Columns.Add(new DataColumn("Currency", typeof(short)));
        var c1 = new DataColumn("Rate", typeof(short));
        c1.AllowDBNull = true;
        tbl.Columns.Add(c1);
        var c2 = new DataColumn("RecipientId", typeof(int));
        c2.AllowDBNull = true;
        tbl.Columns.Add(c2);
        var c3 = new DataColumn("RecipientAccountId", typeof(int));
        c3.AllowDBNull = true;
        tbl.Columns.Add(c3);
        var c4 = new DataColumn("RecipientAmount", typeof(decimal));
        c4.AllowDBNull = true;
        tbl.Columns.Add(c4);
        var c5 = new DataColumn("RecipientCurrency", typeof(short));
        tbl.Columns.Add(c5);

        var transactions = _reader.GetTransactionsForDb((@"D:\Курсы\С#\TransactionModified.csv"));
        for (int i = 0; i < transactions.Count; i++)
        {
            var transaction = transactions[i];
            DataRow dr = tbl.NewRow();
            dr["Id"] = i + 1;
            dr["TransactionId"] = transaction.TransactionId;
            dr["AccountId"] = transaction.AccountId;
            dr["Date"] = transaction.Date;
            dr["TransactionType"] = transaction.TransactionType;
            dr["Amount"] = transaction.Amount;
            dr["Currency"] = transaction.Currency;
            if (transaction.Rate == null)
            {
                dr["Rate"] = DBNull.Value;
                dr["RecipientId"] = DBNull.Value;
                dr["RecipientAccountId"] = DBNull.Value;
                dr["RecipientAmount"] = DBNull.Value;
                dr["RecipientCurrency"] = DBNull.Value;
            }
            else
            {
                dr["Rate"] = transaction.Rate; 
                dr["RecipientId"] = transaction.RecipientId;
                dr["RecipientAccountId"] = transaction.RecipientAccountId;
                dr["RecipientAmount"] = transaction.RecipientAmount;
                dr["RecipientCurrency"] = transaction.RecipientCurrency;
            }

            tbl.Rows.Add(dr);
        }

        string connection = @"Server=.;Database=ReportingService.DB;Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(connection);
        SqlBulkCopy objbulk = new SqlBulkCopy(con);

        objbulk.DestinationTableName = "[ReportingService.DB].[dbo].[Transaction]";
        objbulk.ColumnMappings.Add("Id", "Id");
        objbulk.ColumnMappings.Add("TransactionId", "TransactionId");
        objbulk.ColumnMappings.Add("AccountId", "AccountId");
        objbulk.ColumnMappings.Add("Date", "Date");
        objbulk.ColumnMappings.Add("TransactionType", "TransactionType");
        objbulk.ColumnMappings.Add("Amount", "Amount");
        objbulk.ColumnMappings.Add("Currency", "Currency");
        objbulk.ColumnMappings.Add("Rate", "Rate");
        objbulk.ColumnMappings.Add("RecipientId", "RecipientId");
        objbulk.ColumnMappings.Add("RecipientAccountId", "RecipientAccountId");
        objbulk.ColumnMappings.Add("RecipientAmount", "RecipientAmount");
        objbulk.ColumnMappings.Add("RecipientCurrency", "RecipientCurrency");

        con.Open();
        objbulk.WriteToServer(tbl);
        con.Close();
    }
}
