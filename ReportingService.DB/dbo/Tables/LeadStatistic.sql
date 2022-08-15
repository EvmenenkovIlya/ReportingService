CREATE TABLE [dbo].[LeadStatistic]
(
	Id bigint NOT NULL,
	DateStatistic date NOT NULL,
	LeadId bigint NOT NULL,
	TransactionCountForTwoMonth int NOT NULL,
	DepositsSum decimal(14,4) NOT NULL,
	WithdrawSum decimal(14,4) NOT NULL,
	TransferSum decimal(14,4) NOT NULL,
	DepositCount bigint NOT NULL,
	WithdrawCount bigint NOT NULL,
	TransferCount bigint NOT NULL,
  CONSTRAINT [PK_LEADSTATISTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
