CREATE PROCEDURE [dbo].[LeadOverallStatistic_AddDayStatistic]
	@Statistics LeadOverallStatisticTable ReadOnly
AS
BEGIN
	INSERT INTO [dbo].[LeadOverallStatistic]
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
	select * from @Statistics
END
