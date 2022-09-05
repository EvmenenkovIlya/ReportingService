CREATE PROCEDURE [dbo].[Account_GetCountByCurrency]
	@Currency tinyint
AS
BEGIN
	SELECT 
		Count([Id])
	FROM [dbo].[Account]
	Where Currency = @Currency
END