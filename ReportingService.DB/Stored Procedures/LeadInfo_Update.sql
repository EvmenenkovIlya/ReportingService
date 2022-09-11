﻿CREATE PROCEDURE [dbo].[LeadInfo_Update]
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
	@RegistrationDate date
	
AS
BEGIN
	UPDATE [dbo].[LeadInfo]
	SET 
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Patronymic] = @Patronymic,
		[Phone] = @Phone,
		[Email] = @Email,
		[BirthDate] = @BirthDate,
		[Passport] = @Passport,
		[City] = @City,
		[Address] = @Address,
		[Role] = @Role,
		[RegistrationDate] = @RegistrationDate

	WHERE [LeadId] = @LeadId
END
