CREATE PROCEDURE [dbo].[LeadInformation_Update]
	@Id bigint,
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
		[Patranomyc],
		[Phone],
		[Email],
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
		@Patranomyc,
		@Phone,
		@Email,
		@BirthDate,
		@Passport,
		@City,
		@Address,
		@Role,
		@RegistrationDate,
		@IsDeleted	
	)
	UPDATE [dbo].[LeadInformation]
	SET 
		[LeadId] = @LeadId,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Patranomyc] = @Patranomyc,
		[Phone] = @Phone,
		[Email] = @Email,
		[BirthDate] = @BirthDate,
		[Passport] = @Passport,
		[City] = @City,
		[Address] = @Address,
		[Role] = @Role,
		[RegistrationDate] = @RegistrationDate,
		[IsDeleted] = @IsDeleted

	WHERE Id = @Id
END
