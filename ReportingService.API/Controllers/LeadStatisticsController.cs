using Microsoft.AspNetCore.Mvc;
using ReportingService.Business.Services;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadStatisticsController : Controller
{
    private readonly ILeadOveralStatisticsService _leadStatisticsService;

    private readonly ILogger<LeadStatisticsController> _logger;

    public LeadStatisticsController(ILogger<LeadStatisticsController> logger, ILeadOveralStatisticsService leadStatisticsService)
    {
        _leadStatisticsService = leadStatisticsService;
        _logger = logger;
    }

    [HttpGet("{transactionsCount}/{daysCount}/transactions-count")]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount)
    {
        _logger.LogInformation("Get leads ids whith necessary transactions count");
        return Ok(await _leadStatisticsService.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount));
    }

    [HttpGet("{amountDifference}/{daysCount}/")]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount)
    {
        _logger.LogInformation("Get leads ids whith necessary amount difference");
        return Ok(await _leadStatisticsService.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount));
    }
}
