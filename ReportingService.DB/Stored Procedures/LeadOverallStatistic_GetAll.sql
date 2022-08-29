CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetAll]
AS
BEGIN
	SELECT 
		[Id],
		[DateStatistics],
		[LeadId],
		[DepositsSum],
		[WithdrawSum],
		[TransferSum],
		[DepositsCount],
		[WithdrawalsCount],
		[TransfersCount]
		
	FROM [dbo].[LeadOverallStatistic]
END