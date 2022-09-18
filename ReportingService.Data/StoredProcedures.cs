namespace ReportingService.Data;

public class StoredProcedures
{
    public const string Transaction_GetAll = "Transaction_GetAll";
    public const string Transaction_GetById = "Transaction_GetById";
    public const string Transaction_GetTransactionsByYesterday = "Transaction_GetTransactionsByYesterday";
    public const string Transaction_Add = "Transaction_Add";
    public const string LeadInfo_Add = "LeadInfo_Add";
    public const string LeadInfo_GetAll = "LeadInfo_GetAll";
    public const string LeadInfo_GetByLeadId = "LeadInfo_GetByLeadId";
    public const string LeadInfo_Update = "LeadInfo_Update";
    public const string LeadInfo_UpdateLeadsStatus = "LeadInfo_UpdateLeadsStatus";
    public const string LeadInfo_Delete = "LeadInfo_Delete";
    public const string Leadinfo_GetCelebrateIdsByDate = "Leadinfo_GetCelebrateIdsByDate";
    public const string Account_Add = "Account_Add";
    public const string Account_GetAll = "Account_GetAll";
    public const string Account_GetById = "Account_GetById";
    public const string Account_Update = "Account_Update";
    public const string Account_Delete = "Account_Delete";
    public const string AccountsStatistic_Add = "AccountsStatistic_Add";
    public const string AccountsStatistic_GetAll = "AccountsStatistic_GetAll";
    public const string AccountsStatistic_GetByDate = "AccountsStatistic_GetByDate";
    public const string AccountsStatistic_GetByPeriod = "AccountsStatistic_GetByPeriod";
    public const string LeadOverallStatistic_Add = "LeadOverallStatistic_Add";
    public const string LeadOverallStatistic_GetAll = "LeadOverallStatistic_GetAll";
    public const string LeadOverallStatistic_GetById = "LeadOverallStatistic_GetById";
    public const string LeadOverallStatistic_Update = "LeadOverallStatistic_Update";
    public const string LeadOverallStatistic_GetLeadIdsWithNecessaryTransactionsCount = "LeadOverallStatistic_GetLeadIdsWithNecessaryTransactionsCount";
    public const string LeadOverallStatistic_GetLeadsIdsWithNecessaryAmountDifference = "LeadOverallStatistic_GetLeadsIdsWithNecessaryAmountDifference";
    public const string LeadOverallStatistic_GetLeadOverallStatisticByDate = "LeadOverallStatistic_GetLeadOverallStatisticByDate";
    public const string Statistic_Add = "Statistic_Add";
    public const string Statistic_GetAll = "Statistic_GetAll";
    public const string Statistic_GetByDate = "Statistic_GetByDate";
    public const string Statistic_GetByPeriod = "Statistic_GetByPeriod";
    public const string LeadOverallStatistic_AddDayStatistic = "LeadOverallStatistic_AddDayStatistic";
}
