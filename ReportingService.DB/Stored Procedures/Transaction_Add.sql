CREATE PROCEDURE [dbo].[Transaction_Add]
	@TransactionId bigint,
	@AccountId bigint,
	@Date datetime2,
	@TransactionType tinyint,
	@Amount decimal(14,4),
	@Currency tinyint,
	@Rate decimal(7,4),
	@RecipentId int,
	@RecipientAccountId int,
	@RecipientAmount decimal(14,4),
	@RecipientCurrency tinyint
AS
BEGIN
	INSERT INTO dbo.[Transaction]
	(
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
	)

    VALUES 
	(
		@TransactionId,
		@AccountId,
		@Date,
		@TransactionType,
		@Amount,
		@Currency,
		@Rate,
		@RecipentId,
		@RecipientAccountId,
		@RecipientAmount,
		@RecipientCurrency
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END