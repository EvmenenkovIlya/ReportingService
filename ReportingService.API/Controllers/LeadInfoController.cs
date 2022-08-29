using Microsoft.AspNetCore.Mvc;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadInfoController : ControllerBase
{
    private readonly ILeadInfoRepository _leadInformationsRepository;

    private readonly ILogger<LeadInfoController> _logger;

    public LeadInfoController(ILogger<LeadInfoController> logger, ILeadInfoRepository leadInformationsRepository)
    {
        _leadInformationsRepository = leadInformationsRepository;
        _logger = logger;
    }

    // add period for request
    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetCelebrantsFromDateToNow([FromQuery] DateTime fromDate)
    {
        return Ok(await _leadInformationsRepository.GetCelebrateIdsByDate(DateTime.Now));
    }
}
