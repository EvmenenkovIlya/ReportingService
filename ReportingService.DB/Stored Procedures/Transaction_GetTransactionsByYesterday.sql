CREATE PROCEDURE [dbo].[Transaction_GetTransactionsByYesterday]
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
	WHERE datediff(dd, [Date], (Getdate()- 1)) = 0
END