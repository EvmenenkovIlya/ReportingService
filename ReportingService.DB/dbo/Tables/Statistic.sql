CREATE TABLE [dbo].[AccountsStatistic]
(
	Id bigint NOT NULL,
	DateStatistic date NOT NULL,
	AllLeadsCount int NOT NULL,
	VipLeadsCount int NOT NULL,
	DeletedLeadsCount int NOT NULL,
	DeletedVipsCount int NOT NUll
  CONSTRAINT [PK_ACCOUNTSSTASTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
