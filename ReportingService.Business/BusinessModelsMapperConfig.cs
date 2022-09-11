using AutoMapper;
using IncredibleBackendContracts.Responses;
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
        CreateMap<TransactionCreatedEvent, Transaction>()
            .ForMember(o => o.TransactionId, opt => opt.MapFrom(scr => scr.Id));
    }
}