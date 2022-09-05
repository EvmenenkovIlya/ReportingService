CREATE PROCEDURE [dbo].[AccountsStatistic_Add]
AS
BEGIN
	SELECT 
		[Id]	
		[DateStatistic],
		[AllAccountCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
		
	FROM [dbo].[Statistic]
END

