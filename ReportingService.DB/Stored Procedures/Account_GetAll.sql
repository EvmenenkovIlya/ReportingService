CREATE PROCEDURE [dbo].[Account_GetAll]
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