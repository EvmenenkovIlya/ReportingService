using AutoMapper;
using ReportingService.API.Models;
using ReportingService.Business.Models;

namespace ReportingService.API;

// move to Business
public class APIModelsMapperConfig : Profile
{
    public APIModelsMapperConfig()
    {
        CreateMap<Statistics, StatisticsResponse>()
            .ForMember(x=>x.AccountsStatistic, opt => opt.MapFrom(src => src.AccountsStatistic));
        CreateMap<AccountsStatistic, AccountsStatisticResponse>();
    }
}