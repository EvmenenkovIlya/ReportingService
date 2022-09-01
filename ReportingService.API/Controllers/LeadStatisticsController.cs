using Microsoft.AspNetCore.Mvc;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadStatisticsController : Controller
{
    private readonly ILeadOverallStatisticsRepository _leadStatisticsRepository;

    private readonly ILogger<LeadStatisticsController> _logger;

    public LeadStatisticsController(ILogger<LeadStatisticsController> logger, ILeadOverallStatisticsRepository leadStatisticsRepository)
    {
        _leadStatisticsRepository = leadStatisticsRepository;
        _logger = logger;
    }

    [HttpGet("transactionsCount")]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount)
    {
        return Ok(await _leadStatisticsRepository.GetLeadsIdsWith42Transactions());
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWithNecessaryAmountDifference()
    {
        return Ok(await _leadStatisticsRepository.GetLeadsIdsWithDifferenceOfMore13000());
    }
}
