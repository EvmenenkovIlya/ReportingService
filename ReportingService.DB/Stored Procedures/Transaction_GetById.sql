CREATE PROCEDURE [dbo].[Transaction_GetById]
	@Id bigint
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
	WHERE Id = @Id
END