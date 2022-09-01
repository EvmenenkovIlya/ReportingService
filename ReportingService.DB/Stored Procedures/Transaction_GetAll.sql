CREATE PROCEDURE [dbo].[Transaction_GetAll]
AS
BEGIN
	SELECT 
		[Id],
		[TransactionId],
		[AccountId],
		[Date],
		[TransactionType],
		[Amount],
		[Currency],
		[Rate],
		[RecipientId],
		[RecipientAccountId],
		[RecipientAmount],
		[RecipientCurrency]
	FROM [dbo].[Transaction]
END