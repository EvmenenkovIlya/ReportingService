CREATE PROCEDURE [dbo].[LeadStatistic_Update]
	@Id bigint,
	@DateStatistic date,
	@LeadId bigint,
	@TransactionCountForTwoMontht int,
	@DepositsSum decimal(14,4),
	@WithdrawSum decimal(14,4),
	@TransferSum decimal(14,4),
	@DepositCount int,
	@WithdrawCount int,
	@TransferCount int
	
AS
BEGIN
	UPDATE [dbo].LeadStatistic
	SET 
		[DateStatistic] = @DateStatistic,
		[LeadId] = @LeadId,
		[TransactionCountForTwoMonth] = @TransactionCountForTwoMontht,
		[DepositsSum] = @DepositsSum,
		[WithdrawSum] = @WithdrawSum,
		[TransferSum] = @TransferSum,
		[DepositCount] = @DepositCount,
		[WithdrawCount] = @WithdrawCount,
		[TransferCount] = @TransferCount

	WHERE Id = @Id
END
