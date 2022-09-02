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
        _logger.LogInformation($"Controller: Request to get users who have made transactions greater than {transactionsCount}");
        var result = await _leadStatisticsService.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount);

        _logger.LogInformation($"Controller: users who have made transactions greater than {transactionsCount} returned");
        return Ok(result);
    }

    [HttpGet("{amountDifference}/{daysCount}/amount-difference")]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount)
    {
        _logger.LogInformation($"Controller: Request to get users whose difference between deposits and withdrawals is {amountDifference}");
        var result = await _leadStatisticsService.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount);

        _logger.LogInformation($"Controller: users whose difference between deposits and withdrawals is {amountDifference}");
        return Ok(result);
    }
}
