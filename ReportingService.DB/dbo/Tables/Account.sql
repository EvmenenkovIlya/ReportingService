CREATE TABLE [dbo].[Account]
(
	Id int NOT NULL,
	Currency tinyint NOT NULL,
	Status tinyint NOT NULL,
	LeadId int NOT NULL,
  CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) 
);
