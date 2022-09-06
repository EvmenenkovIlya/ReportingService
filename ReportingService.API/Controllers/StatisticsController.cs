using Microsoft.AspNetCore.Mvc;
using ReportingService.Business.Services;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;
    private readonly ILogger<StatisticsController> _logger;

    public StatisticsController(ILogger<StatisticsController> logger, IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> SaveAccountsStatisticFromYesterday()
    {
        _logger.LogInformation($"Create statistic");
        await _statisticsService.CreateAccountStatistics();
        _logger.LogInformation($"Statistic Created");
        return Ok();
    }
}
