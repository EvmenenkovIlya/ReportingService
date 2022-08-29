CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetLeadsIdsWithDifferenceOfMore13000]
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadOverallStatistic AS Statistic
WHERE abc(Statistic.DepositsSum - Statistic.WithdrawSum) > 13000
END