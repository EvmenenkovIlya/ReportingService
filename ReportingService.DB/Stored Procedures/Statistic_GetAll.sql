CREATE PROCEDURE [dbo].[Statistic_GetAll]
AS
BEGIN
	SELECT 
		[Id]	
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
		
	FROM [dbo].[Statistic]
END

