CREATE PROCEDURE [dbo].[Transaction_GetAll]
AS
BEGIN
	SELECT 
		[Id]
		[AccountId],
		[Date],
		[TransactionType],
		[Amount],
		[Currency],
		[Rate],
		[RecipentId],
		[RecipientAccountId],
		[RecipientAmount],
		[RecipientCurrency]
	FROM [dbo].[Transaction]
END