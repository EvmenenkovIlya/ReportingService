CREATE PROCEDURE [dbo].[Statistic_Add]
	@DateStatistic date,
	@AllLeadsCount int,
	@VipLeadsCount int,
	@DeletedLeadsCount int,
	@DeletedVipLeadsCount int
	
AS
BEGIN
	INSERT INTO dbo.Statistic
	(
		[DateStatistic],
		[AllAccountCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
	)
    VALUES 
	(
		@DateStatistic,
		@AllLeadsCount,
		@VipLeadsCount,
		@DeletedLeadsCount,
		@DeletedVipLeadsCount
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END