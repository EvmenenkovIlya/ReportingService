CREATE PROCEDURE [dbo].[LeadInformation_GetAll]
AS
BEGIN
	SELECT 
		[Id],
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
		
	FROM [dbo].[LeadInformation]
END

