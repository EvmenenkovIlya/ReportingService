CREATE PROCEDURE [dbo].[Account_Add]
AS
BEGIN
	SELECT 
		[Id],
		[Currency],
		[Status],
		[LeadId]
		
	FROM [dbo].[Account]
END