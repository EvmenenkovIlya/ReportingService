CREATE TABLE [dbo].[LeadOverallStatistic]
(
	Id bigint IDENTITY(1,1) NOT NULL,
	DateStatistics date NOT NULL,
	LeadId int NOT NULL,
	DepositsSum decimal(14,4) NULL,
	[WithdrawSum] decimal(14,4) NULL,
	[TransferSum] decimal(14,4) NULL,
	DepositsCount int NULL,
	WithdrawalsCount int NULL,
	TransfersCount int NULL,
  CONSTRAINT [PK_LEADSTATISTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
