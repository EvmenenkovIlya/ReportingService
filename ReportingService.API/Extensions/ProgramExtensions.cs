using IncredibleBackendContracts.Constants;
using MassTransit;
using ReportingService.Business;
using ReportingService.Business.Consumers;
using ReportingService.Business.Services;
using ReportingService.Business.Services.Interfaces;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Extensions;
public static class ProgramExtensions
{
    public static void AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadInfoService, LeadInfoService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
        services.AddScoped<ILeadOverallStatisticsService, LeadOverallStatisticsService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
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
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
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
            config.AddConsumer<LeadsConsumer>();
            config.AddConsumer<TransactionConsumer>();
            config.UsingRabbitMq((ctx, cfg) =>
            {

                cfg.ReceiveEndpoint(RabbitEndpoint.TransactionCreate, c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });
                
                cfg.ReceiveEndpoint(RabbitEndpoint.TransferTransactionCreate, c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

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

                cfg.ReceiveEndpoint(RabbitEndpoint.LeadCreate, c =>
                {
                    c.ConfigureConsumer<LeadsConsumer>(ctx);
                });

                cfg.ReceiveEndpoint(RabbitEndpoint.LeadUpdate, c =>
                {
                    c.ConfigureConsumer<LeadsConsumer>(ctx);
                });

                cfg.ReceiveEndpoint(RabbitEndpoint.LeadsRoleUpdateReporting, c =>
                {
                    c.ConfigureConsumer<LeadsConsumer>(ctx);
                });

                cfg.ReceiveEndpoint(RabbitEndpoint.LeadDelete, c =>
                {
                    c.ConfigureConsumer<LeadsConsumer>(ctx);
                });

                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}
