CREATE PROCEDURE [dbo].[Statistic_Add]
	@DateStatistic date,
	@RegularLeadsCount int,
	@VipLeadsCount int,
	@DeletedLeadsCount int,
	@DeletedVipLeadsCount int
	
AS
BEGIN
	INSERT INTO dbo.Statistic
	(
		[DateStatistic],
		[RegularLeadsCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
	)
    VALUES 
	(
		@DateStatistic,
		@RegularLeadsCount,
		@VipLeadsCount,
		@DeletedLeadsCount,
		@DeletedVipLeadsCount
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END