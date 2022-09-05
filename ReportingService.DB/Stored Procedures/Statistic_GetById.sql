CREATE PROCEDURE [dbo].[Statistic_GetByDate]
	@Date date
AS
BEGIN
	SELECT 
		[Id],
		[DateStatistic],
		[AllAccountCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
		
	FROM [dbo].[Statistic]
	WHERE [DateStatistic] = @Date
END
