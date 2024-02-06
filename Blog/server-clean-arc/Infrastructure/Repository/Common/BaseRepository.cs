using Blog.Application.IRepository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Repository.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        //public IQueryable<T> GetAllWithParam(BaseQueryParameters param, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        //{
        //    return orderBy(_dbSet
        //        .Skip((param.PageNumber - 1) * param.PageSize)
        //        .Take(param.PageSize)
        //        .AsNoTracking());
        //}

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task CreateRange(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            //_dbSet.Update(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRange(IEnumerable<T> entity)
        {
            _dbSet.UpdateRange(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<int> Count()
        {
            return await _dbSet.AsNoTracking().CountAsync();
        }

        public async Task<int> CountByCondition(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AsNoTracking().CountAsync(expression);
        }
    }
}
