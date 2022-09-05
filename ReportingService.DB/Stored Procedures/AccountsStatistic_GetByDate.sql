CREATE PROCEDURE [dbo].[AccountsStatistic_GetByDate]
	@Date date
AS
BEGIN
	SELECT 
		[Id],
		[DateStatistic],
		[Currency tinyint],
		[ActiveAccountCount],
		[FrozenAccountCount],
		[DeletedAccountCount]		
	FROM [dbo].[AccountsStatistic]
	WHERE [DateStatistic] = @Date
END
