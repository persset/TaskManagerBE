namespace TaskManagerBE.Services
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetSingle(int id);
        Task<T> Create(T entity);
        Task<T?> Update(int id, T entity);
        Task<T?> Delete(int id);
    }
}
