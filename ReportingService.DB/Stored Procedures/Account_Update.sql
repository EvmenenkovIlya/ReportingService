CREATE PROCEDURE [dbo].[Account_Update]
	@Id int,
	@AccountId int,
	@Currency tinyint,	
	@Status tinyint,	
	@LeadId int
	
AS
BEGIN
	UPDATE [dbo].Account
	SET 
		[AccountId] = @AccountId,
		[Currency] = @Currency,
		[Status] = @Status,
		[LeadId] = @LeadId

	WHERE Id = @Id
END
