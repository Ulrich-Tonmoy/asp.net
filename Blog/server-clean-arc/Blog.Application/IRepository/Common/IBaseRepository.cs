using Blog.Application.QueryParams;
using System.Linq.Expressions;

namespace Blog.Application.IRepository.Common
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        IQueryable<T> GetAllWithParam(BaseQueryParameters param, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task CreateRange(IEnumerable<T> entity);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entity);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entity);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task<int> Count();
        Task<int> CountByCondition(Expression<Func<T, bool>> expression);
    }
}
