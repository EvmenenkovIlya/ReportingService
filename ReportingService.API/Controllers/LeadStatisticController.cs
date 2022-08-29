using Microsoft.AspNetCore.Mvc;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadStatisticController : Controller
{
    private readonly ILeadStatisticsRepository _leadInformationsRepository;

    private readonly ILogger<LeadInformationsController> _logger;

    public LeadStatisticController(ILogger<LeadInformationsController> logger, ILeadStatisticsRepository leadInformationsRepository)
    {
        _leadInformationsRepository = leadInformationsRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWith42Transactions()
    {
        return Ok(await _leadInformationsRepository.GetLeadsIdsWith42Transactions());
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWithDifferenceOfMore13000()
    {
        return Ok(await _leadInformationsRepository.GetLeadsIdsWithDifferenceOfMore13000());
    }
}
