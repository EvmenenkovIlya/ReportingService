CREATE PROCEDURE [dbo].[Transaction_Add]
	@AccountId bigint,
	@Date datetime2,
	@TransactionType tinyint,
	@Ammount decimal(14,4),
	@Currency smallint,
	@Rate decimal(6,4)
AS
BEGIN
	INSERT INTO dbo.[Transaction]
	(
		[AccountId],
		[Date],
		[TransactionType],
		[Ammount],
		[Currency],
		[Rate]
	)

    VALUES 
	(
		@AccountId,
		@Date,
		@TransactionType,
		@Ammount,
		@Currency,
		@Rate
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END