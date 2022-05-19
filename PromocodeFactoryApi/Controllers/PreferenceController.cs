using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagement;

namespace PromocodeFactoryApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PreferenceController : ControllerBase
    {
        private IRepositoryPreference _preference;
        public PreferenceController(IRepositoryPreference preference)
        {
            _preference = preference;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPreference()
        {
          var preferences =  await _preference.GetAllAsync(); 
            return Ok(preferences);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePreference()
        {
            Preference preference = new Preference() { Name = "Cinema" };
           await _preference.CreateAsync(preference);
            return Ok(preference);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePreference()
        {
            _preference.DeleteAsync(Guid.Parse(""));
            return NoContent(); 
        }
    }
}
