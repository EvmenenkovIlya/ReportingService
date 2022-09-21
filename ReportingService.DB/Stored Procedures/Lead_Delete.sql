CREATE PROCEDURE [dbo].[LeadInfo_Delete]
	@LeadId int
	
AS
BEGIN
	UPDATE [dbo].[LeadInfo]
	SET 
		[IsDeleted] = 1

	WHERE [LeadId] = @LeadId
END
