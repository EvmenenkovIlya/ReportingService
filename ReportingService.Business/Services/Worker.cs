using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using static Quartz.Logging.OperationName;


namespace ReportingService.Business.Services;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Worker> _logger;

    public Worker(IServiceProvider serviceProvider,
    ILogger<Worker> logger) =>
    (_serviceProvider, _logger) = (serviceProvider, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            //await scheduler.Start();
            //IJobDetail job = JobBuilder.Create<StatisticsService>().Build();
            //DateTimeOffset startTime = DateTimeOffset.Parse("01:00 AM");
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("StatisticTrigger", "Statistic")
            //    .StartAt(startTime)
            //    .WithSimpleSchedule(x => x
            //        .RepeatForever())
            //    .Build();
            //await scheduler.ScheduleJob(job, trigger);

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await DoWorkAsync(stoppingToken);
            await Task.Delay(360000, stoppingToken);
        }
    }

    private async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"{nameof(Worker)} is working.");

        //add services
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            IStatisticsService statisticsService = scope.ServiceProvider.GetRequiredService<IStatisticsService>();
            await statisticsService.Execute();

            ILeadOverallStatisticsService leadOverallStatisticsService = scope.ServiceProvider.GetRequiredService<ILeadOverallStatisticsService>();
           await leadOverallStatisticsService.Execute();
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"{nameof(Worker)} is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
