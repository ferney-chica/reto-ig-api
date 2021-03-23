using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoIG.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /*[HttpGet]
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
        }*/


        /*
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return new String[] {"Ferney","Yuliana", "Maria Alejandra" };
        }*/

        [HttpGet]
        public ActionResult Get()
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                var sales = (from sales19 in db.SalesOrderDetails
                            select sales19).ToList();
                return Ok(sales);
            }
            //return new String[] { "Ferney", "Yuliana", "Maria Alejandra" };
        }

    }
}
