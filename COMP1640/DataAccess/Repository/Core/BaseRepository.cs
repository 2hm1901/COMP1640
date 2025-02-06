using Microsoft.EntityFrameworkCore;
using Models.Core;
using System.Linq.Expressions;

namespace DataAccess.Repository.Core;
public class BaseRepository<T>(DbContext context) : IBaseRepository<T> where T : BaseModel
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    private static readonly char[] separator = [','];

    public async Task AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        await _dbSet.AddAsync(entity);
    }
    public async Task DeleteAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        query = query.OrderByDescending(e => e.CreatedDate);

        return await query.ToListAsync();
    }
    public async Task<T?> GetByIdAsync(int id, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;

        query = query.Where(model => model.Id == id);

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.FirstOrDefaultAsync();
    }
    public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.FirstOrDefaultAsync();
    }
    public async Task<bool> IsExist(int id)
    {
        return await _dbSet.FindAsync(id) != null;
    }
    public async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }
}
