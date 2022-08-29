CREATE PROCEDURE [dbo].[LeadStatistic_GetLeadsIdsWith42Transactions]
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadStatistic AS Statistic
WHERE Statistic.TransactionCountForTwoMonth > 41
END