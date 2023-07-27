using MachineServer.DataAccess.Repository.IRepository;
using MachineServer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MachineServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportRepo _reportRepo;
    private readonly ILogger<ReportController> _logger;
    private static readonly string[] Summaries = new[]
     {
         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
     };

    public ReportController(IReportRepo reportRepo, ILogger<ReportController> logger)
    {
        _reportRepo = reportRepo;
        _logger = logger;
    }

    [HttpGet( "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    [HttpGet("GetReports")]
    public async Task<ActionResult<IEnumerable<ReportDto>>> GetReportsAsync()
    {   try
        {
            var reports = await _reportRepo.GetReportsAsync();
            return Ok(reports);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting reports.");
            return StatusCode(500,$"Error occurred while getting reports.{ex.Message}");
        }
    }
}