using HealthChecks.UI.Client;
using IncredibleBackend.Messaging.Extentions;
using IncredibleBackendContracts.Constants;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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
        services.AddHealthChecks();
    }

    public static void ConfigureHeathCheck(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
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
                cfg.ReceiveEndpoint(RabbitEndpoint.TransactionCreate, c =>
                {
                    c.ConfigureConsumer<TransactionCreatedEventConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.TransferTransactionCreate, c =>
                {
                    c.ConfigureConsumer<TransferTransactionCreatedEventConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.AccountCreate, c =>
                {
                    c.ConfigureConsumer<AccountCreatedEventConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.AccountUpdate, c =>
                {
                    c.ConfigureConsumer<AccountUpdatedEventsConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.AccountDelete, c =>
                {
                    c.ConfigureConsumer<AccountDeletedEventsConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.LeadCreate, c =>
                {
                    c.ConfigureConsumer<LeadCreatedEventsConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.LeadUpdate, c =>
                {
                    c.ConfigureConsumer<LeadUpdatedEventsConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.LeadDelete, c =>
                {
                    c.ConfigureConsumer<LeadDeletedEventsConsumer>(ctx);
                });
                cfg.ReceiveEndpoint(RabbitEndpoint.LeadsRoleUpdateReporting, c =>
                {
                    c.ConfigureConsumer<LeadsRoleUpdatedEventsConsumer>(ctx);
                });
            }, null);
    }
}
