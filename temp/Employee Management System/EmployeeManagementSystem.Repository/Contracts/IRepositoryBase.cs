using EmployeeManagementSystem.Common.QueryParameters;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllNoTracking();
        IQueryable<T> GetAllNoTrackingWithParam(QueryParametersBase param, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IQueryable<T> GetAllWithTracking();
        IQueryable<T> GetByConditionNoTracking(Expression<Func<T, bool>> expression);
        IQueryable<T> GetByConditionWithTracking(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddAsyncRange(IEnumerable<T> entity);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entity);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAllAsync();
        Task<int> CountByConditionAsync(Expression<Func<T, bool>> expression);
    }
}
