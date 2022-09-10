CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetLeadOverallStatisticByDate]
	@Date date
AS
BEGIN
	select @Date as 'DateStatistics', t.LeadId, abs(t.DepositsSum) as 'DepositsSum', abs(w.WithdrawalsSum) as 'WithdrawSum', abs(tr.TransfersSum) as 'TransferSum', t.DepositsCount, w.WithdrawalsCount, tr.TransfersCount
  from 
  (select Id as 'LeadId', s.DepositsCount, s.DepositsSum from [dbo].LeadInfo
  left join 
    (select DISTINCT LeadId, count(Amount) as 'DepositsCount', sum(Amount) as 'DepositsSum' from [dbo].[Transaction] as t
    full join [dbo].[Account] as a on a.AccountId = t.AccountId and t.TransactionType = 1
    where YEAR(t.Date) = YEAR(@Date) and month(t.Date) = month(@Date) and day(t.Date) = day(@Date)
    group by LeadId) as s on Id = s.LeadId) as t

    join (select Id as 'LeadId', s.WithdrawalsCount, s.WithdrawalsSum from [dbo].LeadInfo
  left join 
    (select DISTINCT LeadId, count(Amount) as 'WithdrawalsCount', sum(Amount) as 'WithdrawalsSum' from [dbo].[Transaction] as t
    full join [dbo].[Account] as a on a.AccountId = t.AccountId and t.TransactionType = 2
    where YEAR(t.Date) = YEAR(@Date) and month(t.Date) = month(@Date) and day(t.Date) = day(@Date)
    group by LeadId) as s on Id = s.LeadId) as w on w.LeadId = t.LeadId

    join (select Id as 'LeadId', s.TransfersCount, s.TransfersSum from [dbo].LeadInfo
  left join 
    (select DISTINCT LeadId, count(Amount) as 'TransfersCount', sum(Amount) as 'TransfersSum' from [dbo].[Transaction] as t
    full join [dbo].[Account] as a on a.AccountId = t.AccountId and t.TransactionType = 3
    where YEAR(t.Date) = YEAR(@Date) and month(t.Date) = month(@Date) and day(t.Date) = day(@Date)
    group by LeadId) as s on Id = s.LeadId) as tr on tr.LeadId = t.LeadId
  order by t.LeadId

END