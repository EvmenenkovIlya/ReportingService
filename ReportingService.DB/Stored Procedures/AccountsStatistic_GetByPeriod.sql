CREATE PROCEDURE [dbo].[AccountsStatistic_GetByPeriod]
	@DateFrom date,
	@DateTo date
AS
BEGIN
	SELECT 
		[Id],
		[DateStatistic],
		[Currency],
		[ActiveAccountCount],
		[FrozenAccountCount],
		[DeletedAccountCount]		
	FROM [dbo].[AccountsStatistic]
	WHERE [DateStatistic] between @DateFrom and @DateTo
END
