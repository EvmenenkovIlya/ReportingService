using AutoMapper;
using IncredibleBackendContracts.Responses;
using IncredibleBackendContracts.Enums;
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
        CreateMap<TransactionCreatedEvent, Transaction>()
            .ForMember(o => o.TransactionId, opt => opt.MapFrom(scr => scr.Id));
        CreateMap<TransferTransactionCreatedEvent, Transaction>()
            .ForMember(o => o.TransactionId, opt => opt.MapFrom(scr => scr.Id));

        CreateMap<AccountCreatedEvent, Account>()
            .ForMember(o => o.AccountId, opt => opt.MapFrom(src => src.Id));
        CreateMap<LeadCreatedEvent, LeadInfo>()
            .ForMember(o => o.LeadId, opt => opt.MapFrom(src => src.Id))
            .ForMember(o => o.BirthDate, opt => opt.MapFrom(src => src.Birthday))
            .AfterMap((src, dest) => dest.Role = Role.Regular);
        CreateMap<LeadUpdatedEvent, UpdateLeadInfo>()
            .ForMember(o => o.LeadId, opt => opt.MapFrom(src => src.Id))
            .ForMember(o => o.BirthDate, opt => opt.MapFrom(src => src.Birthday));
        CreateMap<UpdateLeadInfo, LeadInfoDto>();
    }
}