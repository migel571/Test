using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagement;

namespace PromocodeFactoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IRepositoryCustomer _customer;
        private IRepositoryPreference _preference;
        public CustomerController(IRepositoryCustomer customer, IRepositoryPreference preference)
        {
            _customer = customer;
            _preference = preference;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customers = await _customer.GetAllAsync();
            return Ok(customers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerPost()
        {
            var preference = await _preference.GetListAsync("Theatre");
            Customer customer = new Customer() { Email = "dydyd@mail.ru", FirstName = "Ovesh", LastName = "Mike", };
            customer.Preferences = preference;
            await _customer.CreateAsync(customer);
            return Ok(customer.FirstName);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer()
        {
            await _customer.DeleteAsync(Guid.Parse("64391394-a3c6-4a14-856a-9ab3507dcec5"));
            await _customer.DeleteAsync(Guid.Parse("69ff9df7-fa48-4c2e-ae7c-18168adb6cf4"));
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer()
        {

            // var preference = await _preference.GetListAsync("Theatre");
            Customer customer = await _customer.GetAsync("Ovesh"); //new Customer() {CustomerId=Guid.Parse("69ff9df7-fa48-4c2e-ae7c-18168adb6cf4"), Email = "dydyd@mail.ru", FirstName = "Ageichikov", LastName = "Igor", };
            //customer.Preferences = preference;
            var preference = await _preference.GetAsync("Theatre");
            var preference_new = await _preference.GetAsync("Cinema");
            customer.Preferences.Remove(preference);
            customer.Preferences.Add(preference_new);
            await _customer.UpdateAsync(customer);
            return Ok(customer.FirstName);
        }

    }
}
