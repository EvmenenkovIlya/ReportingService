using ReportingService.Business.Exceptions;

namespace ReportingService.Business;

public static class Validator
{
    public static void CheckThatObjectNotNull<T>(T obj, string errorMessage)
    {
        if (obj == null)
        {
            throw new BadRequestException(errorMessage);
        }
    }

    public static void ValidateDates(DateTime dateFrom, DateTime dateTo, string errorMessage)
    {
        if (dateFrom.Date > dateTo.Date)
        {
            throw new BadRequestException(errorMessage);
        }
    }
}
