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

    /// <summary>
    ///  0 - today
    /// </summary>
    /// <param name="daysCount"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetCelebrantsFromDateToNow([FromQuery] int daysCount)
    {
        _logger.LogInformation($"GetCelebrantsFromDateToNow with date {DateTime.Now.AddDays(-daysCount)}");
        var result = await _leadInfoService.GetCelebrantsFromDateToNow(daysCount);
        _logger.LogInformation($"GetCelebrantsFromDateToNow returned list with {result.Count} Id");
        return Ok(result);
    }
}
