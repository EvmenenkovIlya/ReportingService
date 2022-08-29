CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetLeadsIdsWith42Transactions]
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadOverallStatistic AS Statistic
WHERE Id = 1
END