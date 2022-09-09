using MassTransit;
using ReportingService.Business;
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
            config.AddConsumer<TransactionConsumer>();
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.ReceiveEndpoint("transaction-queue", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("lead-delete", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("account-delete", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("lead-update", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("account-update", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("lead-create", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

                cfg.ReceiveEndpoint("account-create", c =>
                {
                    c.ConfigureConsumer<TransactionConsumer>(ctx);
                });

            });
        });
    }
}
