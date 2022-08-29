CREATE PROCEDURE [dbo].[LeadInfo_GetById]
	@Id bigint
AS
BEGIN
	SELECT 
		[Id],
		[LeadId],
		[FirstName],
		[LastName],
		[Patronymic],
		[Phone],
		[Email],
		[BirthDate],
		[Passport],
		[City],
		[Address],
		[Role],
		[RegistrationDate],
		[IsDeleted]
		
	FROM [dbo].[LeadInfo]
	WHERE Id = @Id
END
