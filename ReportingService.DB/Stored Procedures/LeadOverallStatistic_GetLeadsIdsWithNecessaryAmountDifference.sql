CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetLeadsIdsWithNecessaryAmountDifference]
@Date date,
@AmountDifference decimal
AS
    BEGIN
        select [LeadId] from [dbo].LeadOverallStatistic as ls
        where ls.DateStatistics > @Date
        group by ls.LeadId
        Having abs(sum(ls.DepositsSum) - sum(ls.WithdrawSum)) > @AmountDifference 
END