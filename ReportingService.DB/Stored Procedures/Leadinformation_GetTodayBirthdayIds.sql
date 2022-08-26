CREATE PROCEDURE [dbo].[LeadInformation_GetTodayBirthdayIds]
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadInformation AS Info
WHERE DATEDIFF(dd, DATEFROMPARTS(YEAR(GetDate()), MONTH(Info.BirthDate), DAY(Info.BirthDate)), GetDate()) between 0 and 13
END
