CREATE PROCEDURE [dbo].[Statistic_GetByPeriod]
	@DateFrom date,
	@DateTo date
AS
BEGIN
	SELECT
	[DateStatistic],
	[RegularLeadsCount],
	[VipLeadsCount],
    [DeletedLeadsCount],
    [DeletedVipLeadsCount]
FROM [dbo].[Statistic]
WHERE [Statistic].[DateStatistic] between @DateFrom and @DateTo
END
