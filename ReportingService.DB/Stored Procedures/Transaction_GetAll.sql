CREATE PROCEDURE [dbo].[Transaction_GetAll]
AS
BEGIN
	SELECT 
		[Id]
		[AccountId],
		[Date],
		[TransactionType],
		[Ammount],
		[Currency],
		[Rate]
	FROM [dbo].[Transaction]
END