CREATE PROCEDURE [dbo].[LeadStatistic_Update]
	@Id bigint,
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
	INSERT INTO dbo.LeadInformation
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
	UPDATE [dbo].[LeadInformation]
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
