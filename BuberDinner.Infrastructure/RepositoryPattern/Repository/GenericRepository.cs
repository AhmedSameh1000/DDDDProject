using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BuberDinner.Infrastructure.Data;
using BuberDinner.Infrastructure.RepositoryPattern.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.RepositoryPattern.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(T Entity)
        {
            await _dbContext.AddAsync(Entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T Entity)
        {
            _dbContext.Remove(Entity);
            return await SaveChangesAsync();
        }

        public async Task<T> GetFirstOrDefault(
            Expression<Func<T, bool>> filter,
            string[] InclueProperties = null
        )
        {
            IQueryable<T> Query = _dbContext.Set<T>().AsQueryable();
            Query = Query.Where(filter);
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return await Query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetList(string[] InclueProperties = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>().AsQueryable();
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return await Query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T Entity)
        {
            _dbContext.Update(Entity);
            return await SaveChangesAsync();
        }
    }
}
