using Cronos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Infarstracture;


namespace ReportingService.Business.Services;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Worker> _logger;
    private readonly CronExpression _cronJob;

    public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger =  logger;
        _cronJob = CronExpression.Parse(Constants.CronExpression, CronFormat.IncludeSeconds);
    }
    

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Statistic Worker running at: {time}", DateTimeOffset.Now);

            var now = DateTime.UtcNow;
            var nextUtc = _cronJob.GetNextOccurrence(now);
            var delayTimeSpan = (nextUtc.Value - now);
            await Task.Delay(delayTimeSpan, stoppingToken);
            await DoWorkAsync(stoppingToken);
        }
    }

    private async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"{nameof(Worker)} is working.");

        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            IStatisticsService statisticsService = scope.ServiceProvider.GetRequiredService<IStatisticsService>();
            await statisticsService.Execute();

            ILeadOverallStatisticsService leadOverallStatisticsService = scope.ServiceProvider.GetRequiredService<ILeadOverallStatisticsService>();
           //await leadOverallStatisticsService.Execute();
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"{nameof(Worker)} is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
