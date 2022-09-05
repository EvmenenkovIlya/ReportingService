CREATE PROCEDURE [dbo].[AccountsStatistic_Add]
	@DateStatistic date,
	@Currency tinyint,
	@ActiveAccountCount int,
	@FrozenAccountCount int,
	@DeletedAccountCount int
	
AS
BEGIN
	INSERT INTO dbo.AccountsStatistic
	(
		[DateStatistic],
		[Currency tinyint],
		[ActiveAccountCount],
		[FrozenAccountCount],
		[DeletedAccountCount]
	)
    VALUES 
	(
		@DateStatistic,
		@Currency,
		@ActiveAccountCount,
		@FrozenAccountCount,
		@DeletedAccountCount
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END