CREATE PROCEDURE [dbo].[Account_Add]
	@AccountId int,
	@Currency tinyint,	
	@Status tinyint,	
	@LeadId int
	
AS
BEGIN
	INSERT INTO [dbo].[Account]
	(
		[AccountId],
		[Currency],
		[Status],
		[LeadId]
	)
    VALUES 
	(
		@AccountId,
		@Currency,
		@Status,
		@LeadId
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END