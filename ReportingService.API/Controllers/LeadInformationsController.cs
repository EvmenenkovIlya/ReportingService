using Microsoft.AspNetCore.Mvc;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadInformationsController : ControllerBase
{
    private readonly ILeadInformationsRepository _leadInformationsRepository;

    private readonly ILogger<LeadInformationsController> _logger;

    public LeadInformationsController(ILogger<LeadInformationsController> logger, ILeadInformationsRepository leadInformationsRepository)
    {
        _leadInformationsRepository = leadInformationsRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<int>>> GetLeadsIdsWithBirthday()
    {
        return Ok(await _leadInformationsRepository.GetAllBirthdayIds());
    }
}