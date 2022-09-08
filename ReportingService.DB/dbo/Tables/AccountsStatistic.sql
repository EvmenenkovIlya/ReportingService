CREATE TABLE [dbo].[AccountsStatistic]
(
	Id bigint IDENTITY(1,1) NOT NULL,
	DateStatistic date NOT NULL,
	Currency tinyint NOT NULL,
	ActiveAccountCount int NOT NULL,
	FrozenAccountCount int NOT NULL,
	DeletedAccountCount int NOT NULL
  CONSTRAINT [PK_STASTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
