using AutoMapper;
using IncredibleBackendContracts.Events;
using ReportingService.Business.Models;
using ReportingService.Data.Dto;

namespace ReportingService.Business;

public class BusinessModelsMapperConfig : Profile
{
    public BusinessModelsMapperConfig()
    {
        CreateMap<AccountDto, Account>().ReverseMap();
        CreateMap<LeadInfoDto, LeadInfo>().ReverseMap();
        CreateMap<LeadOverallStatisticsDto, LeadOverallStatistics>().ReverseMap();
        CreateMap<StatisticsDto, Statistics>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();

        CreateMap<AccountCreatedEvent, Account>()
            .ForMember(o => o.AccountId, opt => opt.MapFrom(src => src.Id));
        CreateMap<LeadCreatedEvent, LeadInfo>();
        CreateMap<LeadUpdatedEvent, LeadInfo>();

    }
}