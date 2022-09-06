CREATE TABLE [dbo].[LeadOverallStatistic]
(
	Id bigint IDENTITY(1,1) NOT NULL,
	DateStatistics date NOT NULL,
	LeadId int NOT NULL,
	DepositsSum decimal(14,4) NOT NULL,
	[WithdrawSum] decimal(14,4) NOT NULL,
	[TransferSum] decimal(14,4) NOT NULL,
	DepositsCount int NOT NULL,
	WithdrawalsCount int NOT NULL,
	TransfersCount int NOT NULL,
  CONSTRAINT [PK_LEADSTATISTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
