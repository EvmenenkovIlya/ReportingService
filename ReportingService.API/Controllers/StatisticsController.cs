using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportingService.API.Models;
using ReportingService.Business.Services;

namespace ReportingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;
    private readonly ILogger<StatisticsController> _logger;
    private readonly IMapper _mapper;

    public StatisticsController(ILogger<StatisticsController> logger, IStatisticsService statisticsService, IMapper mapper)
    {
        _statisticsService = statisticsService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("by-dates")]
    public async Task<ActionResult<List<StatisticsResponse>>> GetStatisticsByDates([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
    {
        var result = await _statisticsService.GetStatisticsByPeriod(dateFrom, dateTo);
        return Ok(_mapper.Map<List<StatisticsResponse>>(result));
    }
}
