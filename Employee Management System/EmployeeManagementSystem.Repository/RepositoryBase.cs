using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext employeeManagementSystemContext)
        {
            _dbSet = employeeManagementSystemContext.Set<T>();
        }

        public IQueryable<T> GetAllNoTracking()
        {
            return _dbSet.AsNoTracking();
        }
        public IQueryable<T> GetAllNoTrackingWithParam(QueryParametersBase param, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return orderBy(_dbSet
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .AsNoTracking());
        }

        public IQueryable<T> GetAllWithTracking()
        {
            return _dbSet.AsTracking();
        }

        public IQueryable<T> GetByConditionNoTracking(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }
        public IQueryable<T> GetByConditionWithTracking(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsTracking();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task AddAsyncRange(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task UpdateRange(IEnumerable<T> entity)
        {
            _dbSet.UpdateRange(entity);
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<int> CountAllAsync()
        {
            return await _dbSet.AsNoTracking().CountAsync();
        }

        public async Task<int> CountByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AsNoTracking().CountAsync(expression);
        }
    }
}
