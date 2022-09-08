CREATE TABLE [dbo].[Account]
(
	Id int IDENTITY(1,1) NOT NULL,
	AccountId int NOT NULL,
	Currency tinyint NOT NULL,
	Status tinyint NOT NULL,
	LeadId int NOT NULL,
	IsDeleted bit NOT NULL DEFAULT 0
  CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);
