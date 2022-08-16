CREATE TABLE [dbo].[LeadInformation]
(
	Id bigint NOT NULL,
	LeadId bigint NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Patranomyc nvarchar(50) NOT NULL,
	BirthDate date NOT NULL,
	Email nvarchar(50) NOT NULL,
	Phone nvarchar(15) NOT NULL,
	Passport nvarchar(10) NOT NULL,
	City nvarchar(50) NOT NULL,
	Address nvarchar(50) NOT NULL,
	Role tinyint NOT NULL,
	Password nvarchar(50) NOT NULL,
	RegistrationDate date NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_LEADINFORMATION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);