using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AssetController> _logger;

        public AssetController(ILogger<AssetController> logger)
        {
            _logger = logger;
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

        [HttpPost]
        public IActionResult Post()
        {
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put()
        {
            return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return StatusCode(500);
        }
    }
}
