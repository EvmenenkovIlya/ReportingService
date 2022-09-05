CREATE TABLE [dbo].[LeadInfo]
(
	Id int NOT NULL,
	LeadId int NOT NULL,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Patronymic nvarchar(20) NOT NULL,
	BirthDate date NOT NULL,
	Email nvarchar(50) NOT NULL,
	Phone nvarchar(15) NOT NULL,
	Passport nvarchar(11) NOT NULL,
	City tinyint NOT NULL,
	Address nvarchar(50) NOT NULL,
	Role tinyint NOT NULL,
	RegistrationDate date NOT NULL,
	IsDeleted bit NOT NULL
  CONSTRAINT [PK_LEADINFORMATION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);