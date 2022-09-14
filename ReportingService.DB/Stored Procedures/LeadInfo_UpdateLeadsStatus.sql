CREATE PROCEDURE [dbo].[LeadInfo_UpdateLeadsStatus]
    @ids intTable READONLY
AS
BEGIN
    
     UPDATE [dbo].[LeadInfo]
	 SET [Role] = 2 
     where [LeadId] in (select Id from @ids)
     Update [dbo].[LeadInfo]
	 SET [Role] = 1 
     where [LeadId] not in (select Id from @ids)
END