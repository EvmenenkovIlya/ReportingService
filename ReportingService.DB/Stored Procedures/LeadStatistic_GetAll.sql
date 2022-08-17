CREATE PROCEDURE [dbo].[LeadStatistic_GetAll]
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
END