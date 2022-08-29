CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetById]
	@Id bigint
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
	WHERE Id = @Id
END
