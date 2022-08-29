CREATE PROCEDURE [dbo].[LeadOverallStatistic_Add]
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
	INSERT INTO dbo.LeadOverallStatistic
	(
		[DateStatistics],
		[LeadId],
		[DepositsSum],
		[WithdrawSum],
		[TransferSum],
		[DepositsCount],
		[WithdrawalsCount],
		[TransfersCount]
	)
    VALUES 
	(
		@DateStatistics,
		@LeadId,
		@DepositsSum,
		@WithdrawSum,
		@TransferSum,
		@DepositsCount,
		@WithdrawalsCount,
		@TransfersCount
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END