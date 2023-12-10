using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.RepositoryPattern.IRepository
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<bool> CreateAsync(T Entity);
        Task<bool> DeleteAsync(T Entity);
        Task<bool> UpdateAsync(T Entity);
        Task<T> GetFirstOrDefault(
            Expression<Func<T, bool>> filter,
            string[] InclueProperties = null
        );
        Task<IEnumerable<T>> GetList(string[] InclueProperties = null);

        Task<bool> SaveChangesAsync();
    }
}
