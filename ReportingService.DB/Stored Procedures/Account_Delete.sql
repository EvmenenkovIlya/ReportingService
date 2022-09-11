CREATE PROCEDURE [dbo].[Account_Delete]
	@AccountId int
	
AS
BEGIN
	UPDATE [dbo].Account
	SET 
		[IsDeleted] = 1

	WHERE AccountId = @AccountId
END
