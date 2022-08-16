CREATE PROCEDURE [dbo].[LeadStatistic_GetById]
	@Id bigint
AS
BEGIN
	SELECT 
		[Id],
		[DateStatistic],
		[LeadId],
		[TransactionCountForTwoMonth],
		[DepositsSum],
		[WithdrawSum],
		[TransferSum],
		[DepositCount],
		[WithdrawCount],
		[TransferCount]
		
	FROM [dbo].[LeadStatistic]
	WHERE Id = @Id
END
