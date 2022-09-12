using AutoMapper;
using ReportingService.Business.Exceptions;
using ReportingService.Data.Repositories;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Data.Dto;

namespace ReportingService.Business.Services;

public class LeadInfoService : ILeadInfoService
{
    private readonly ILeadInfoRepository _leadInfoRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public LeadInfoService(ILeadInfoRepository leadInfoRepository, ILogger<LeadInfoService> logger, IMapper mapper)
    {
        _leadInfoRepository = leadInfoRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<int>> GetCelebrantsFromDateToNow(int daysCount)
    {
        ValidateDaysCount(daysCount);
        var listDates = GetDatesFromDateToNow(daysCount);
        var results = await Task.WhenAll(listDates.Select(async date =>
        {
            var list = await _leadInfoRepository.GetCelebrateIdsByDate(date);
            return list;
        }));
        var result = Concat(results);
        _logger.LogInformation($"Db returned {results.Count()} lists with {result.Count} id");
        return result;
    }

    public async Task AddLeadInfo(LeadInfo leadInfo)
    {
        var lead = _mapper.Map<LeadInfoDto>(leadInfo);
        _logger.LogInformation("");
        await _leadInfoRepository.AddLeadInfo(lead);
    }

    public Task<List<int>> GetCelebrateIdsByDate(DateTime date)
    {
        _logger.LogInformation("");
        throw new NotImplementedException();
    }

    public Task<List<LeadInfo>> GetAllLeadInfoDto()
    {
        _logger.LogInformation("");
        throw new NotImplementedException();
    }

    public Task<LeadInfo> GetLeadInfoDtoByLeadId(int leadId)
    {
        _logger.LogInformation("");
        throw new NotImplementedException();
    }

    public Task UpdateLeadInfo(UpdateLeadInfo leadInformation)
    {
        _logger.LogInformation("");
        throw new NotImplementedException();
    }

    public Task DeleteLeadInfo(int leadId)
    {
        _logger.LogInformation("");
        throw new NotImplementedException();
    }

    public Task UpdateLeadsStatus(List<int> vipIds)
    {
        _logger.LogInformation("");
        throw new NotImplementedException();
    }


    private List<TType> Concat<TType>(params List<TType>[] lists)
    {
        var result = lists.Aggregate(new List<TType>(), (x, y) => x.Concat(y).ToList());
        return result;
    }

    private List<DateTime> GetDatesFromDateToNow(int daysCount)
    {
        DateTime fromDate = DateTime.Now.AddDays(-daysCount);
        return Enumerable.Range(0, (DateTime.Now - fromDate).Days + 1)
        .Select(i => fromDate.AddDays(i))
        .ToList();
    }

    private void ValidateDaysCount(int daysCount)
    {
        if (daysCount > 366 || daysCount < 0) 
        {
            throw new BadRequestException("Number of days most be bigger then 0 and less the 365");
        }
    }
}