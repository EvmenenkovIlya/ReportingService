CREATE PROCEDURE [dbo].[Account_GetById]
	@Id bigint
AS
BEGIN
	SELECT 
		[Id],
		[Currency],
		[Status],
		[LeadId]
		
	FROM [dbo].[Account]
	WHERE Id = @Id
END