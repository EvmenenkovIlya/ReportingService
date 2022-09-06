CREATE TABLE [dbo].[Statistic]
(
	Id bigint IDENTITY(1,1) NOT NULL,
	DateStatistic date NOT NULL,
	RegularLeadsCount int NOT NULL,
	VipLeadsCount int NOT NULL,
	DeletedLeadsCount int NOT NULL,
	DeletedVipLeadsCount int NOT NUll
  CONSTRAINT [PK_ACCOUNTSSTASTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
