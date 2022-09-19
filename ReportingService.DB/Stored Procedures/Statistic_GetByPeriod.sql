CREATE PROCEDURE [dbo].[Statistic_GetByPeriod]
		@Date dateTable READONLY
AS
BEGIN
	SELECT
		[DateStatistic],
		[RegularLeadsCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount],
		SUM([DepositsSum]) as DepositsSum,
		SUM([WithdrawSum]) as WithdrawSum,
		SUM([TransferSum]) as TransferSum,
		SUM([DepositsCount]) as DepositsCount,
		SUM([WithdrawalsCount]) as WithdrawalsCount,
		SUM([TransfersCount]) as TransfersCount		
FROM [dbo].[Statistic]
join [dbo].LeadOverallStatistic on DateStatistic = DateStatistics
WHERE [DateStatistic] = (Select [Date] from @Date)
group by [DateStatistic],
		[RegularLeadsCount],
		[VipLeadsCount],
		[DeletedLeadsCount],
		[DeletedVipLeadsCount]
end