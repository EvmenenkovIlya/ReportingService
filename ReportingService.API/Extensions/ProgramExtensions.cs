using IncredibleBackendContracts.Constants;
using IncredibleBackendContracts.Events;
using MassTransit;
using ReportingService.Business;
using ReportingService.Business.Consumers;
using ReportingService.Business.Services;
using ReportingService.Data.Repositories;
using T_Strore.Business.Consumers;

namespace ReportingService.API.Extensions;
public static class ProgramExtensions
{
    public static void AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadInfoService, LeadInfoService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
        services.AddScoped<ILeadOverallStatisticsService, LeadOverallStatisticsService>();
        services.AddScoped<IAccountsService, AccountsService>();
    }

    public static void AddDataLayerRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAccountsRepository, AccountsRepository>();
        services.AddScoped<ILeadInfoRepository, LeadInfoRepository>();
        services.AddScoped<ILeadOverallStatisticsRepository, LeadOverallStatisticsRepository>();
        services.AddScoped<IStatisticsRepository, StatisticsRepository>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<IAccountsStatisticsRepository, AccountsStatisticsRepository>();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(APIModelsMapperConfig));
        services.AddAutoMapper(typeof(BusinessModelsMapperConfig));
    }

    public static void AddMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.AddConsumer<AccountsConsumer>();
            config.AddConsumer<LeadConsumer>();
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.ReceiveEndpoint(RabbitEndpoint.AccountCreate, c =>
                {
                    c.ConfigureConsumer<AccountsConsumer>(ctx);
                });

                cfg.ReceiveEndpoint(RabbitEndpoint.AccountUpdate, c =>
                {
                    c.ConfigureConsumer<AccountsConsumer>(ctx);
                });

                cfg.ReceiveEndpoint(RabbitEndpoint.AccountDelete, c =>
                {
                    c.ConfigureConsumer<AccountsConsumer>(ctx);
                });

                //cfg.ReceiveEndpoint(RabbitEndpoint.LeadCreate, c =>
                //{
                //    c.ConfigureConsumer<LeadConsumer>(ctx);
                //});

                //cfg.ReceiveEndpoint(RabbitEndpoint.LeadUpdate, c =>
                //{
                //    c.ConfigureConsumer<LeadConsumer>(ctx);
                //});

                //cfg.ReceiveEndpoint(RabbitEndpoint.LeadsRoleUpdateReporting, c =>
                //{
                //    c.ConfigureConsumer<LeadConsumer>(ctx);
                //});

                //cfg.ReceiveEndpoint(RabbitEndpoint.LeadDelete, c =>
                //{
                //    c.ConfigureConsumer<LeadConsumer>(ctx);
                //});
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}
