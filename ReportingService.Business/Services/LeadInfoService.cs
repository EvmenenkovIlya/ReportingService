using ReportingService.Data.Repositories;

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
        var listDates = GetDatesFromDateToNow(fromDate);
        var results = await Task.WhenAll(listDates.Select(async date =>
        {
            var list = await _leadInfoRepository.GetCelebrateIdsByDate(date);
            return list;
        }));
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
}