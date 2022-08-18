CREATE TABLE [dbo].[Statistic]
(
	Id bigint NOT NULL,
	DateStatistic date NOT NULL,
	Currency tinyint NOT NULL,
	ActiveAccountCount bigint NOT NULL,
	AllAccountCount bigint NOT NULL,
	ActiveLeadCount bigint NOT NULL,
  CONSTRAINT [PK_STASTIC] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
