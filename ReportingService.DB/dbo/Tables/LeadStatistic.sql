CREATE TABLE [dbo].[LeadStatistic]
(
	Id bigint NOT NULL,
	DateStatistic date NOT NULL,
	LeadId int NOT NULL,
	TransactionCountForTwoMonth int NOT NULL,
	DepositsSum decimal(14,4) NOT NULL,
	WithdrawSum decimal(14,4) NOT NULL,
	TransferSum decimal(14,4) NOT NULL,
	DepositCount int NOT NULL,
	WithdrawCount int NOT NULL,
	TransferCount int NOT NULL,
  CONSTRAINT [PK_LEADSTATISTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
