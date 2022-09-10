CREATE PROCEDURE [dbo].[Statistic_Add]
	
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
		Getdate() - 1,
		(Select Count([Id]) from LeadInfo where [Role] = 1 and [IsDeleted] = 0),
		(Select Count([Id]) from LeadInfo where [Role] = 2 and [IsDeleted] = 0),
		(Select Count([Id]) from LeadInfo where [Role] = 1 and [IsDeleted] = 1),
		(Select Count([Id]) from LeadInfo where [Role] = 2 and [IsDeleted] = 1)
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END