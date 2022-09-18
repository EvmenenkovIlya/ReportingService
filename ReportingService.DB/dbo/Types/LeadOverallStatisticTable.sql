CREATE TYPE [dbo].[LeadOverallStatisticTable] AS TABLE(
    [DateStatistics] [date] not null,
    [LeadId] [int] not null,
    [DepositsSum] [decimal](14,4) not null,
    [WithdrawSum] [decimal](14,4) not null,
    [TransferSum] [decimal](14,4) not null,
    [DepositsCount] [int] not null,
    [WithdrawalsCount] [int] not null,
    [TransfersCount] [int] not null
)
