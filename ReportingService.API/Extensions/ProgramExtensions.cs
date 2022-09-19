using IncredibleBackend.Messaging.Extentions;
using IncredibleBackendContracts.Constants;
using ReportingService.Business;
using ReportingService.Business.Consumers;
using ReportingService.Business.Services;
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

    public static void AddConsumers(this IServiceCollection services)
    {
        services.RegisterConsumersAndProducers(
            (config) =>
            {
                config.AddConsumer<TransactionCreatedEventConsumer>();
                config.AddConsumer<TransferTransactionCreatedEventConsumer>();
                config.AddConsumer<AccountCreatedEventConsumer>();
                config.AddConsumer<AccountUpdatedEventsConsumer>();
                config.AddConsumer<AccountDeletedEventsConsumer>();
                config.AddConsumer<LeadCreatedEventsConsumer>();
                config.AddConsumer<LeadUpdatedEventsConsumer>();
                config.AddConsumer<LeadDeletedEventsConsumer>();
                config.AddConsumer<LeadsRoleUpdatedEventsConsumer>();
            },
            (cfg, ctx) =>
            {
                cfg.RegisterConsumer<TransactionCreatedEventConsumer>(ctx, RabbitEndpoint.TransactionCreate);
                cfg.RegisterConsumer<TransferTransactionCreatedEventConsumer>(ctx, RabbitEndpoint.TransferTransactionCreate);
                cfg.RegisterConsumer<AccountCreatedEventConsumer>(ctx, RabbitEndpoint.AccountCreate);
                cfg.RegisterConsumer<AccountUpdatedEventsConsumer>(ctx, RabbitEndpoint.AccountUpdate);
                cfg.RegisterConsumer<AccountDeletedEventsConsumer>(ctx, RabbitEndpoint.AccountDelete);
                cfg.RegisterConsumer<LeadCreatedEventsConsumer>(ctx, RabbitEndpoint.LeadCreate);
                cfg.RegisterConsumer<LeadUpdatedEventsConsumer>(ctx, RabbitEndpoint.LeadUpdate);
                cfg.RegisterConsumer<LeadDeletedEventsConsumer>(ctx, RabbitEndpoint.LeadDelete);
                cfg.RegisterConsumer<LeadsRoleUpdatedEventsConsumer>(ctx, RabbitEndpoint.LeadsRoleUpdateReporting);
            }, null);
    }
}
