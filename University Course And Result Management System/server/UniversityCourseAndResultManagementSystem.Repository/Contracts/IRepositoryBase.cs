using System.Linq.Expressions;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;

namespace UniversityCourseAndResultManagementSystem.Repository.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllNoTrackingWithParam(QueryParametersBase param, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IQueryable<T> GetByConditionNoTracking(Expression<Func<T, bool>> expression);
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
