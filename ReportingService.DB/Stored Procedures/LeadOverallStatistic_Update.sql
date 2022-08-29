CREATE PROCEDURE [dbo].[LeadOverallStatistic_Update]
	@Id bigint,
	@DateStatistics date,
	@LeadId int,
	@DepositsSum decimal(14,4),
	@WithdrawSum decimal(14,4),
	@TransferSum decimal(14,4),
	@DepositsCount int,
	@WithdrawalsCount int,
	@TransfersCount int
	
AS
BEGIN
	UPDATE [dbo].LeadOverallStatistic
	SET 
		[DateStatistics] = @DateStatistics,
		[LeadId] = @LeadId,
		[DepositsSum] = @DepositsSum,
		[WithdrawSum] = @WithdrawSum,
		[TransferSum] = @TransferSum,
		[DepositsCount] = @DepositsCount,
		[WithdrawalsCount] = @WithdrawalsCount,
		[TransfersCount] = @TransfersCount

	WHERE Id = @Id
END
