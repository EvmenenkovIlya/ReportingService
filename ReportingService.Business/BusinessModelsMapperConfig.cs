using AutoMapper;
using ReportingService.Business.Models;
using ReportingService.Data.Dto;

namespace ReportingService.Business;

// move to Business
public class BusinessModelsMapperConfig : Profile
{
    public BusinessModelsMapperConfig()
    {
        CreateMap<AccountDto, Account>().ReverseMap();
        CreateMap<LeadInfoDto, LeadInfo>().ReverseMap();
        CreateMap<LeadOverallStatisticsDto, LeadOverallStatistics>().ReverseMap();
        CreateMap<StatisticsDto, Statistics>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();
    }
}