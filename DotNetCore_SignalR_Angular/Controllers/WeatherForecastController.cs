

using System;
using DotNetCore_SignalR_Angular.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace DotNetCore_SignalR_Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static HubConnection connection;


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public String Get()
        {
            if (connection == null)
            {
                connection = new Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder().WithUrl("https://localhost:44300/contador").Build();

                connection.StartAsync();
            }
            connection.InvokeAsync("somaContador");

            return "OK";
        }
    }
}
