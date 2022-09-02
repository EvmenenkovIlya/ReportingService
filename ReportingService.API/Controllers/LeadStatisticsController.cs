using Microsoft.AspNetCore.Mvc;
using ReportingService.Business.Services;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadStatisticsController : Controller
{
    private readonly ILeadOveralStatisticsService _leadStatisticsRepository;

    private readonly ILogger<LeadStatisticsController> _logger;

    public LeadStatisticsController(ILogger<LeadStatisticsController> logger, ILeadOveralStatisticsService leadStatisticsRepository)
    {
        _leadStatisticsRepository = leadStatisticsRepository;
        _logger = logger;
    }

    [HttpGet("transactions-count")]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount)
    {
        return Ok(await _leadStatisticsRepository.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount));
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWithNecessaryAmountDifference()
    {
        return Ok(await _leadStatisticsRepository.GetLeadsIdsWithDifferenceOfMore13000());
    }
}
