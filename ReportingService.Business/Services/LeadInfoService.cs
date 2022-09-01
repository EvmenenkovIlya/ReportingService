using Microsoft.Extensions.Options;
using ReportingService.Business.Exceptions;
using ReportingService.Data.Repositories;
using System.Diagnostics;

namespace ReportingService.Business.Services;

public class LeadInfoService : ILeadInfoService
{
    private readonly ILeadInfoRepository _leadInfoRepository;

    public LeadInfoService(ILeadInfoRepository leadInfoRepository)
    {
        _leadInfoRepository = leadInfoRepository;
    }

    public async Task<List<int>> GetCelebrantsFromDateToNow(DateTime fromDate)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        ValidateDate(fromDate);
        var listDates = GetDatesFromDateToNow(fromDate);
        var results = await Task.WhenAll(listDates.Select(async date =>
        {
            var list = await _leadInfoRepository.GetCelebrateIdsByDate(date);
            return list;
        }));

        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;

        return Concat(results);
    }

        

    private List<TType> Concat<TType>(params List<TType>[] lists)
    {
        var result = lists.Aggregate(new List<TType>(), (x, y) => x.Concat(y).ToList());
        return result;
    }

    private List<DateTime> GetDatesFromDateToNow(DateTime fromDate)
    {
        return Enumerable.Range(0, (DateTime.Now - fromDate).Days + 1)
        .Select(i => fromDate.AddDays(i))
        .ToList();
    }

    private void ValidateDate(DateTime fromDate)
    {
        var today = DateTime.Now.Date;
        if (fromDate.Date > today && (today - fromDate.Date).TotalDays < 366) 
        {
            throw new BadRequestException("Date must be less or equal than today");
        }
    }
}