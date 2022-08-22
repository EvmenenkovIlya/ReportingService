using Microsoft.AspNetCore.Mvc;
using ReportingService.Data.Repositoties;

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
    public ActionResult<List<int>> GetLeadsIdsWithBirthday()
    {
        return _leadInformationsRepository.GetAllBirthdayIds();
    }
}