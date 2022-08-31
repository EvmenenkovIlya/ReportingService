CREATE PROCEDURE [dbo].[Transaction_GetById]
	@Id bigint
AS
BEGIN
	SELECT 
		[Id]
		[TransactionId],
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
	WHERE Id = @Id
END