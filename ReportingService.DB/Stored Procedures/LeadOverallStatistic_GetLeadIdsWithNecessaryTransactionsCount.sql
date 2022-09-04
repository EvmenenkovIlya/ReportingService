CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetLeadIdsWithNecessaryTransactionsCount]
    @Date date,
    @TransactionsCount int
AS
    BEGIN
        select [LeadId] from [dbo].LeadOverallStatistic as ls
        where ls.DateStatistics > @Date
        group by ls.LeadId
        having sum(ls.DepositsCount) + sum(ls.TransfersCount) > @TransactionsCount
END