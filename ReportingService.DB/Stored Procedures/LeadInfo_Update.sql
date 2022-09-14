CREATE PROCEDURE [dbo].[LeadInfo_Update]
	@LeadId int,
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@Patronymic nvarchar(20),
	@BirthDate date,
	@Phone nvarchar(20),
	@City tinyint,
	@Address nvarchar(50)
	
AS
BEGIN
	UPDATE [dbo].[LeadInfo]
	SET 
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Patronymic] = @Patronymic,
		[Phone] = @Phone,
		[BirthDate] = @BirthDate,
		[City] = @City,
		[Address] = @Address,

	WHERE [LeadId] = @LeadId
END
