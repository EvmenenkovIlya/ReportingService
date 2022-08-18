CREATE PROCEDURE [dbo].[LeadStatistic_Add]
	@DateStatistic date,
	@LeadId int,
	@TransactionCountForTwoMontht int,
	@DepositsSum decimal(14,4),
	@WithdrawSum decimal(14,4),
	@TransferSum decimal(14,4),
	@DepositCount int,
	@WithdrawCount int,
	@TransferCount int
AS
BEGIN
	INSERT INTO dbo.LeadStatistic
	(
		[DateStatistic],
		[LeadId],
		[TransactionCountForTwoMonth],
		[DepositsSum],
		[WithdrawSum],
		[TransferSum],
		[DepositCount],
		[WithdrawCount],
		[TransferCount]
	)
    VALUES 
	(
		@DateStatistic,
		@LeadId,
		@TransactionCountForTwoMontht,
		@DepositsSum,
		@WithdrawSum,
		@TransferSum,
		@DepositCount,
		@WithdrawCount,
		@TransferCount
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END