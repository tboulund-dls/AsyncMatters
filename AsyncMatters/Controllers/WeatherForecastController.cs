using Microsoft.AspNetCore.Mvc;

namespace AsyncMatters.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("GetSync")]
    public IEnumerable<WeatherForecast> GetSync()
    {
        Thread.Sleep(5000);
        return FetchWeatherForecast();
    }
    
    [HttpGet("GetAsync")]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        await Task.Delay(5000);
        return FetchWeatherForecast();
    }

    private IEnumerable<WeatherForecast> FetchWeatherForecast()
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