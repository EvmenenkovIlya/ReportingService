using AutoMapper;
using ReportingService.Business.Exceptions;
using ReportingService.Data.Repositories;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Infarstracture;
using ReportingService.Business.Models;
using ReportingService.Data.Dto;
using static MassTransit.ValidationResultExtensions;

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
        _logger.LogInformation($"LeadInfoService try to get vips with {listDates.Count} requests to Database");
        var results = await Task.WhenAll(listDates.Select(async date =>
        {
            var list = await _leadInfoRepository.GetCelebrateIdsByDate(date);
            return list;
        }));
        var result = Concat(results);
        _logger.LogInformation($"Database returned {results.Count()} lists with {result.Count} id");
        return result;
    }

    public async Task AddLeadInfo(LeadInfo leadInfo)
    {
        var lead = _mapper.Map<LeadInfoDto>(leadInfo);
        _logger.LogInformation($"LeadInfoService try to add new Lead info with LeadId = {leadInfo.LeadId}");
        await _leadInfoRepository.AddLeadInfo(lead);
    }


    public async Task<List<LeadInfo>> GetAllLeadInfo()
    {
        _logger.LogInformation($"LeadInfoService try to get all Leads");
        var listDtos = await _leadInfoRepository.GetAllLeadInfoDto();
        var result = _mapper.Map<List<LeadInfo>>(listDtos);
        _logger.LogInformation($"LeadInfoRepository returned {result.Count} Leads");
        return result;
    }

    public async Task<LeadInfo> GetLeadInfoByLeadId(int leadId)
    {
        _logger.LogInformation($"LeadInfoService try to get Lead with LeadId = {leadId}");
        var dto = await _leadInfoRepository.GetLeadInfoDtoByLeadId(leadId);
        Validator.CheckThatObjectNotNull(dto, ExceptionsErrorMessages.LeadInfoNotFound);
        var result = _mapper.Map<LeadInfo>(dto);
        _logger.LogInformation($"LeadInfoRepository returned LeadInfoDto with LeadId = {result.LeadId}");
        return result;
    }

    public async Task UpdateLeadInfo(UpdateLeadInfo leadInformation)
    {
        _logger.LogInformation($"LeadInfoRepository try to update Lead with LeadId = {leadInformation.LeadId}");
        var leadToUpdate = _mapper.Map<LeadInfoDto>(leadInformation);
        await _leadInfoRepository.UpdateLeadInfo(leadToUpdate);
    }

    public async Task DeleteLeadInfo(int leadId)
    {
        _logger.LogInformation($"LeadInfoService try to delete Lead with LeadId = {leadId}");
        await _leadInfoRepository.DeleteLeadInfo(leadId);
    }

    public async Task UpdateLeadsStatus(List<int> vipIds)
    {
        _logger.LogInformation($"LeadInfoService try to update Leads status count leads= {vipIds.Count}");
        await _leadInfoRepository.UpdateLeadsStatus(vipIds);
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