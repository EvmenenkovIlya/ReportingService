CREATE PROCEDURE [dbo].[LeadInfo_Add]
	@LeadId int,
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@Patronymic nvarchar(20),
	@BirthDate date,
	@Phone nvarchar(20),
	@Email nvarchar(50),
	@Passport nvarchar(10),
	@City tinyint,
	@Address nvarchar(50),
	@Role tinyint,
	@RegistrationDate date,
	@IsDeleted bit	
	
AS
BEGIN
	INSERT INTO dbo.LeadInfo
	(
		[LeadId],
		[FirstName],
		[LastName],
		[Phone],
		[Email],
		[Patronymic],
		[BirthDate],
		[Passport],
		[City],
		[Address],
		[Role],
		[RegistrationDate],
		[IsDeleted]
	)
    VALUES 
	(
		@LeadId,
		@FirstName,
		@LastName,
		@Phone,
		@Email,
		@Patronymic,
		@BirthDate,
		@Passport,
		@City,
		@Address,
		@Role,
		@RegistrationDate,
		@IsDeleted	
	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END