﻿CREATE PROCEDURE [dbo].[AccountsStatistic_GetByDate]
	@Date date
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
	WHERE [DateStatistic] = @Date
END