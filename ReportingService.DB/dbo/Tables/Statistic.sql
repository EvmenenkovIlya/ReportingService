CREATE TABLE [dbo].[Statistic]
(
	Id bigint NOT NULL,
	DateStatistic date NOT NULL,
	DepositCount bigint NOT NULL,
	WithdrawCount bigint NOT NULL,
	TransferCount bigint NOT NULL,
	DepositSum decimal(14,4) NOT NULL,
	WithdrawSum decimal(14,4) NOT NULL,
	TransferSum decimal(14,4) NOT NULL,
	ActiveAccountCount bigint NOT NULL,
	AllAccountCount bigint NOT NULL,
	ActiveLeadCount bigint NOT NULL,
  CONSTRAINT [PK_STASTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
