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

        var leads = _reader.GetLeads(@"D:\Курсы\С#\LeadFiltered.csv");
        for (int i = 0; i < leads.Count; i++)
        {
            var lead = (Lead)leads[i];
            DataRow dr = tbl.NewRow();
            dr["Id"] = i + 1;
            dr["LeadId"] = lead.LeadId;
            dr["FirstName"] = lead.FirstName;
            dr["LastName"] = lead.LastName;
            dr["Patronymic"] = lead.Patronymic;
            var bd = lead.BirthDate;
            dr["BirthDate"] = bd;
            dr["Email"] = lead.Email;
            dr["Phone"] = lead.Phone;
            dr["Passport"] = lead.Passport;
            dr["City"] = lead.City;
            dr["Address"] = lead.Address;
            dr["Role"] = lead.Role;
            var rg = lead.RegistrationDate;
            dr["RegistrationDate"] = rg;
            dr["IsDeleted"] = lead.IsDeleted;
            tbl.Rows.Add(dr);
        }

        string connection = @"Server=.;Database=ReportingService.DB;Trusted_Connection=True;";
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

    //[Test]
    public void BulkInsertAccounts()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(int)));
        tbl.Columns.Add(new DataColumn("AccountId", typeof(int)));
        tbl.Columns.Add(new DataColumn("Currency", typeof(int)));
        tbl.Columns.Add(new DataColumn("Status", typeof(int)));
        tbl.Columns.Add(new DataColumn("LeadId", typeof(int)));


        var accounts = _reader.GetAccounts((@"D:\Курсы\С#\AccountFiltered.csv"));
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

        string connection = @"Server=.;Database=ReportingService.DB;Trusted_Connection=True;";
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
}
