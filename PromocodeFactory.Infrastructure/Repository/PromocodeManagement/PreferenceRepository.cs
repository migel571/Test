using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagement
{
    public class PreferenceRepository : IRepositoryPreference
    {
        private readonly PromocodeContext _context;
        private readonly DbSet<Preference> _dbSet;
        public PreferenceRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<Preference>();
        }

        public async Task<IEnumerable<Preference>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Preference> GetAsync(string name)
        {
            return await _dbSet.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Preference preference)
        {
            _dbSet.AddAsync(preference);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Preference preference)
        {
            _dbSet.Update(preference);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid preferenceId)
        {
            var preference = await _dbSet.FindAsync(preferenceId);
            if (preference == null) return;
            _dbSet.Remove(preference);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Preference>> GetListAsync(string name)
        {
           return await _dbSet.Where(x=>x.Name==name).ToListAsync();
            
            
        }


    }
}
