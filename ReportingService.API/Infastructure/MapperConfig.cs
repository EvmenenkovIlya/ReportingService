using AutoMapper;
using ReportingService.Business.Models;
using ReportingService.Data.Dto;

namespace ReportingService.API;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<AccountDto, Account>().ReverseMap();
        CreateMap<LeadInformationDto, LeadInformation>().ReverseMap();
        CreateMap<LeadStatisticDto, LeadStatistic>().ReverseMap();
        CreateMap<StatisticDto, Statistic>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();
    }
}