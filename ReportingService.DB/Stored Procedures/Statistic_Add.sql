CREATE PROCEDURE [dbo].[Statistic_Add]
	@DateStatistic date,
	@DepositCount bigint,
	@WithdrawCount bigint,
	@TransferCount bigint,
	@DepositSum decimal,
	@WithdrawSum decimal,
	@TransferSum decimal,
	@ActiveAccountCount bigint,
	@AllAccountCount bigint,
	@ActiveLeadCount bigint
	
AS
BEGIN
	INSERT INTO dbo.Statistic
	(
		[DateStatistic],
		[DepositCount],
		[WithdrawCount],
		[TransferCount],
		[DepositSum],
		[WithdrawSum],
		[TransferSum],
		[ActiveAccountCount],
		[AllAccountCount],
		[ActiveLeadCount]
	)
    VALUES 
	(
		@DateStatistic,
		@DepositCount,
		@WithdrawCount,
		@TransferCount,
		@DepositSum,
		@WithdrawSum,
		@TransferSum,
		@ActiveAccountCount,
		@AllAccountCount,
		@ActiveLeadCount
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END