CREATE PROCEDURE [dbo].[Account_Update]
	@AccountId int,
	@Status tinyint	
	
AS
BEGIN
	UPDATE [dbo].Account
	SET 
		[Status] = @Status

	WHERE AccountId = @AccountId
END
