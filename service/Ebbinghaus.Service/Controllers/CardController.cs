using Microsoft.AspNetCore.Mvc;

namespace Ebbinghaus.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CardController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet()]
    public IEnumerable<WeatherForecast> Get()
    {
    
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
