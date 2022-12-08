using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository
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

        public IQueryable<T> GetByConditionNoTracking(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
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
