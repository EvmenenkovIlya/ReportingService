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
}
