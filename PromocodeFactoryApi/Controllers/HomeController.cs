using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;

namespace PromocodeFactoryApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILoggerManager _logger;
        private IRepositoryRole _role;
        private IRepositoryEmployee _employee;
        public HomeController(ILoggerManager logger, IRepositoryRole role, IRepositoryEmployee employee)
        {
            _logger = logger;
            _role = role;
            _employee = employee;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    _logger.LogInfo("Here is info message from the controller.");
        //    _logger.LogDebug("Here is debug message from the controller.");
        //    _logger.LogWarning("Here is warn message from the controller.");
        //    _logger.LogError("Here is error message from the controller.");
        //    return new string[] { "value1", "value2" };
        //}
      
        [HttpGet]
        public async Task<IActionResult> EmployeeGet()
        {
            var categories = await _employee.GetAllAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeePost()
        {
            Employee r = new Employee() { Email = "dfd@mail.ru", FirstName = "fd", LastName = "sds", RoleId = Guid.Parse("d40088e3-e55e-4c59-b541-ecf848bbacbb"), AppliedPromocodesCount = 1 };
            await _employee.CreateAsync(r);

            return Created("", "");
        }
        [HttpDelete]
        public async Task<IActionResult> EmployeeDelete()
        {
            await _employee.DeleteAsync(Guid.Parse("c7b2557a-4d36-46de-927e-e2cf17a6a1ff"));

            return NoContent();
        }
        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}