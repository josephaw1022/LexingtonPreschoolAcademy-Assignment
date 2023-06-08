using Microsoft.AspNetCore.Mvc;
using LexingtonPreschoolAcademy_Database;


namespace LexingtonPreschoolAcademy_API.Controllers;

[ApiController]
[Route("health")]
public class HealthCheck : ControllerBase
{


    private readonly IConfiguration _configuration;

    public HealthCheck(
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }


    [HttpGet("check")]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            Version = _configuration["LexingtonPreschoolAcademyDatabaseContext"] ?? "Not found"
        });
    }


    [HttpGet("ping-db")]
    public async Task<IActionResult> PingDb(
        [FromServices] LexingtonPreschoolAcademyDatabaseContext dbContext
    )
    {
        return await dbContext.Database.CanConnectAsync()
            ? Ok() : StatusCode(500);
    }



}
