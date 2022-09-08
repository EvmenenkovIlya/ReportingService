CREATE PROCEDURE [dbo].[Statistic_GetAll]
AS
BEGIN
	SELECT 
		[Id]	
		[DateStatistic],
		[RegularLeadsCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
		
	FROM [dbo].[Statistic]
END

