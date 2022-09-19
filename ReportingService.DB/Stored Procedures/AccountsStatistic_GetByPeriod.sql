CREATE PROCEDURE [dbo].[AccountsStatistic_GetByPeriod]
	@Date dateTable READONLY
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
	WHERE [DateStatistic] = (Select [Date] from @Date)
END
