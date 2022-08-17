CREATE PROCEDURE [dbo].[Account_Update]
	@Id bigint,
	@Currency tinyint,	
	@Status tinyint,	
	@LeadId bigint
	
AS
BEGIN
	INSERT INTO dbo.Account
	(
		[Currency],
		[Status],
		[LeadId]
	)
    VALUES 
	(
		@Currency,
		@Status,
		@LeadId
	)
	UPDATE [dbo].Account
	SET 
		[Currency] = @Currency,
		[Status] = @Status,
		[LeadId] = @LeadId

	WHERE Id = @Id
END
