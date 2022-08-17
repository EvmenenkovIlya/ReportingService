CREATE PROCEDURE [dbo].[Account_Add]
	@Currency tinyint,	
	@Status tinyint,	
	@LeadId int
	
AS
BEGIN
	INSERT INTO dbo.Account
	(
		[Currency],
		[Status],
		[LeadId]
	)
    VALUES 
	(
		@Currency,
		@Status,
		@LeadId
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END