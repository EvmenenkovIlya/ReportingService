using Microsoft.AspNetCore.Mvc;
using ReportingService.Business.Services;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadInfoController : ControllerBase
{
    private readonly ILeadInfoService _leadInfoService;
    private readonly ILogger<LeadInfoController> _logger;

    public LeadInfoController(ILogger<LeadInfoController> logger, ILeadInfoService leadInfoService)
    {
        _leadInfoService = leadInfoService;
        _logger = logger;
    }

    // add period for request
    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetCelebrantsFromDateToNow([FromQuery] DateTime fromDate)
    {
        _logger.LogInformation("Hello world");
        return Ok(await _leadInfoService.GetCelebrantsFromDateToNow(fromDate));
    }
}
