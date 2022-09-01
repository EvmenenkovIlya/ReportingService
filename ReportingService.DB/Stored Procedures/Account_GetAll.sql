CREATE PROCEDURE [dbo].[Account_Add]
AS
BEGIN
	SELECT 
		[Id],
		[AccountId],
		[Currency],
		[Status],
		[LeadId]
		
	FROM [dbo].[Account]
END