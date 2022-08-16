CREATE PROCEDURE [dbo].[LeadStatistic_Add]
	@DateStatistic date,
	@LeadId bigint,
	@TransactionCountForTwoMontht int,
	@DepositsSum decimal,
	@WithdrawSum decimal,
	@TransferSum decimal,
	@DepositCount bigint,
	@WithdrawCount bigint,
	@TransferCount bigint
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