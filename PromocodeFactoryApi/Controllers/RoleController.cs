using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;

namespace PromocodeFactoryApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
       
       
        private IRepositoryRole _role;
       
        public RoleController(ILoggerManager logger, IRepositoryRole role,IRepositoryEmployee employee)
        {
           
            _role = role;
            
        }

        
        [HttpGet]
        public async Task<IActionResult>  RoleGet()
        {
            var categories = await _role.GetAllAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> RolePost()
        {
            Role r = new Role(){RoleName = "Admin", Description = "Good"};
             await _role.CreateAsync(r);

            return Created("", "");
        }
        [HttpDelete]
        public async Task<IActionResult> RoleDelete()
        {
            await _role.DeleteAsync(Guid.Parse("d40088e3-e55e-4c59-b541-ecf848bbacbb"));

            return NoContent();
        }
        
    }
}