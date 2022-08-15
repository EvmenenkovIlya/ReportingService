CREATE TABLE [dbo].[Account]
(
	Id bigint NOT NULL,
	Currency tinyint NOT NULL,
	Status tinyint NOT NULL,
	LeadId tinyint NOT NULL,
  CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) 
);
