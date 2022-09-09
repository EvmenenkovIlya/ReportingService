using ReportingService.Business.Services;

namespace ReportingService.API;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Worker> _logger;

    public Worker(IServiceProvider serviceProvider,
    ILogger<Worker> logger) =>
    (_serviceProvider, _logger) = (serviceProvider, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        /*while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await DoWorkAsync(stoppingToken);
            await Task.Delay(60000, stoppingToken);
        }*/
    }

    private async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        /*_logger.LogInformation(
            $"{nameof(Worker)} is working.");

        //add services
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            IStatisticsService statisticsService = scope.ServiceProvider.GetRequiredService<IStatisticsService>();
            await statisticsService.Execute();
        }*/
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
       /* _logger.LogInformation(
            $"{nameof(Worker)} is stopping.");

        await base.StopAsync(stoppingToken);*/
    }
}
