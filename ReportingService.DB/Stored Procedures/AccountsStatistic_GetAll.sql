CREATE PROCEDURE [dbo].[AccountsStatistic_GetAll]
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
END
