CREATE PROCEDURE [dbo].[LeadInformation_GetTodayBirthdayIds]
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadInformation AS Info
WHERE MONTH(Info.BirthDate) = MONTH(GetDate()) and Day(Info.BirthDate) = Day(GetDate())
END
