CREATE PROCEDURE [dbo].[Statistic_GetByPeriod]
	@DateFrom date,
	@DateTo date
AS
BEGIN
	SELECT 
		[Id],
		[DateStatistic],
		[RegularLeadsCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
		
	FROM [dbo].[Statistic]
	WHERE [DateStatistic] between @DateFrom and @DateTo
END
