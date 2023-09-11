namespace LeaveManagement.Application.IRepository.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}
