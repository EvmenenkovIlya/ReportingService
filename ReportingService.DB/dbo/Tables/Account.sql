CREATE TABLE [dbo].[Account]
(
	Id int NOT NULL,
	AccountId int NOT NULL,
	Currency tinyint NOT NULL,
	Status tinyint NOT NULL,
	LeadId int NOT NULL,
	IsDeleted bit NOT NULL
  CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) 
);
