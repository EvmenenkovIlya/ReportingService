CREATE PROCEDURE [dbo].[LeadOverallStatistic_GetLeadOverallStatistics]
    @Date date
AS
    BEGIN
        select t.LeadId, @Date as 'DateStatistic', t.DepositCount, abs(t.DepositSum) as 'DepositSum', w.WithdrawCount, abs(w.WithdrawSum) as 'WithdrawSum', tr.TransferCount, abs(tr.TransferSum) as 'TransferSum'
  from 
  (select Id as 'LeadId', s.DepositCount, s.DepositSum from [dbo].LeadInfo
  left join 
    (select DISTINCT LeadId, count(Amount) as 'DepositCount', sum(Amount) as 'DepositSum' from [dbo].[Transaction] as t
    full join [dbo].[Account] as a on a.AccountId = t.AccountId and t.TransactionType = 1
    where YEAR(t.Date) = YEAR(@Date) and month(t.Date) = month(@Date) and day(t.Date) = day(@Date)
    group by LeadId) as s on Id = s.LeadId) as t

    join (select Id as 'LeadId', s.WithdrawCount, s.WithdrawSum from [dbo].LeadInfo
  left join 
    (select DISTINCT LeadId, count(Amount) as 'WithdrawCount', sum(Amount) as 'WithdrawSum' from [dbo].[Transaction] as t
    full join [dbo].[Account] as a on a.AccountId = t.AccountId and t.TransactionType = 2
    where YEAR(t.Date) = YEAR(@Date) and month(t.Date) = month(@Date) and day(t.Date) = day(@Date)
    group by LeadId) as s on Id = s.LeadId) as w on w.LeadId = t.LeadId

    join (select Id as 'LeadId', s.TransferCount, s.TransferSum from [dbo].LeadInfo
  left join 
    (select DISTINCT LeadId, count(Amount) as 'TransferCount', sum(Amount) as 'TransferSum' from [dbo].[Transaction] as t
    full join [dbo].[Account] as a on a.AccountId = t.AccountId and t.TransactionType = 3
    where YEAR(t.Date) = YEAR(@Date) and month(t.Date) = month(@Date) and day(t.Date) = day(@Date)
    group by LeadId) as s on Id = s.LeadId) as tr on tr.LeadId = t.LeadId
  order by t.LeadId
END