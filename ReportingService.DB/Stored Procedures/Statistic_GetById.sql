CREATE PROCEDURE [dbo].[Statistic_GetById]
	@Id bigint
AS
BEGIN
	SELECT 
		[Id],
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
	WHERE Id = @Id
END
