using Hangfire;
using Lab11_MiguelQuispe.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_MiguelQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataCleanupController : ControllerBase
{
    private readonly IDataCleanupService _dataCleanupService;

    public DataCleanupController(IDataCleanupService dataCleanupService)
    {
        _dataCleanupService = dataCleanupService;
    }

    [HttpPost("run")]
    public IActionResult RunCleanup()
    {
        BackgroundJob.Enqueue(() => _dataCleanupService.CleanOldData());
        return Ok("Limpieza de datos programada para ejecutarse inmediatamente.");
    }
    
    [HttpPost("schedule-daily")]
    public IActionResult ScheduleDailyCleanup()
    {
        RecurringJob.AddOrUpdate<IDataCleanupService>(
            "daily-data-cleanup",
            service => service.CleanOldData(),
            Cron.Daily //
        );
        return Ok("Limpieza de datos programada diariamente.");
    }
    [HttpPost("run-delayed")]
    public IActionResult RunDelayedCleanup()
    {
        BackgroundJob.Schedule(() => _dataCleanupService.CleanOldData(), TimeSpan.FromMinutes(5));
        return Ok("Limpieza programada para ejecutarse en 5 minutos.");
    }
}