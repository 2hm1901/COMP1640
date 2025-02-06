using Models.Core;
using System.Linq.Expressions;

namespace DataAccess.Repository.Core;
public interface IBaseRepository<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    Task<T?> GetByIdAsync(int id, string? includeProperties = null);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> IsExist(int id);

}
