using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;

namespace PromocodeFactoryApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
       
      
        
        private IRepositoryEmployee _employee;
        public EmployeeController(ILoggerManager logger, IRepositoryRole role, IRepositoryEmployee employee)
        {
           
          
            _employee = employee;
        }

       
      
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
       
    }
}