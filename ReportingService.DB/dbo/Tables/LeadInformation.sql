CREATE TABLE [dbo].[LeadInformation]
(
	Id bigint NOT NULL,
	LeadId bigint NOT NULL,
	FirstName nvarchar NOT NULL,
	LastName nvarchar NOT NULL,
	Patranomyc nvarchar NOT NULL,
	BirthDate date NOT NULL,
	Email nvarchar NOT NULL,
	Phone nvarchar NOT NULL,
	Passport nvarchar NOT NULL,
	City nvarchar NOT NULL,
	Address nvarchar NOT NULL,
	Role tinyint NOT NULL,
	Password nvarchar NOT NULL,
	RegistrationDate date NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_LEADINFORMATION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);