CREATE PROCEDURE [dbo].[AccountsStatistic_GetAll]
AS
BEGIN
	SELECT 
		[Id]	
		[DateStatistic],
		[Currency tinyint],
		[ActiveAccountCount],
		[FrozenAccountCount],
		[DeletedAccountCount]
		
	FROM [dbo].[AccountsStatistic]
END

