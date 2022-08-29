CREATE PROCEDURE [dbo].[LeadStatistic_GetLeadsIdsWithDifferenceOfMore13000]
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadStatistic AS Statistic
WHERE abc(Statistic.DepositsSum - Statistic.WithdrawSum) > 13000
END