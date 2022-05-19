using PromocodeFactory.Domain.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagement
{
    public interface IRepositoryCustomer
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(string firstName);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
    }
}
