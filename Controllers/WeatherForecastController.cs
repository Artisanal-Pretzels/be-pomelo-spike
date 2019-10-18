using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using be_pomelo_spike.Models;

namespace be_pomelo_spike.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly LocationItemContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, LocationItemContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    //     public static void InsertData()
    //     {
    //       using (var context = new LocationItemContext())
    //       {
    //         context.Database.EnsureCreated();

    //         var todoItem = new LocationItem
    //         {
    //           Latitude = 99,
    //           Longitude = 100,
    //           Name = "Pomelo connection?",
    //         };
    //         context.LocationItem.Add(todoItem);

    //         context.SaveChanges();
    //       }
    //     }
  }
}
