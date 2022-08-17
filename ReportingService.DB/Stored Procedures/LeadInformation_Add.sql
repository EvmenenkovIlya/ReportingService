CREATE PROCEDURE [dbo].[LeadInformation_Add]
	@LeadId bigint,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Patranomyc nvarchar(50),
	@BirthDate date,
	@Phone nvarchar(50),
	@Email nvarchar(50),
	@Passport nvarchar(10),
	@City nvarchar(50),
	@Address nvarchar(50),
	@Role tinyint,
	@RegistrationDate date,
	@IsDeleted bit	
	
AS
BEGIN
	INSERT INTO dbo.LeadInformation
	(
		[LeadId],
		[FirstName],
		[LastName],
		[Phone],
		[Email],
		[Patranomyc],
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
		@Patranomyc,
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