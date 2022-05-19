using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagement
{

    public class CustomerRepository : IRepositoryCustomer
    {
        private PromocodeContext _context;
        private DbSet<Customer> _dbSet;
        public CustomerRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Customer> GetAsync(string firstName)
        {
            return await _dbSet.Where(x => x.FirstName == firstName).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Customer customer)
        {
            _dbSet.AddAsync(customer);
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _dbSet.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await _dbSet.FindAsync(customerId);
            if (customer == null)
                return;
            _dbSet.Remove(customer);
            await _context.SaveChangesAsync();
        }



    }
}
