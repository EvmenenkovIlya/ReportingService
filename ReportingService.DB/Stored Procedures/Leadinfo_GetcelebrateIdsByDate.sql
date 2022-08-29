CREATE PROCEDURE [dbo].[Leadinfo_GetCelebrateIdsByDate]
    @Date date
AS
    BEGIN
        SELECT [Id]
    FROM dbo.LeadInfo AS Info
WHERE MONTH(Info.BirthDate) = MONTH(@Date) AND DAY(Info.BirthDate) = DAY(@Date)
END
