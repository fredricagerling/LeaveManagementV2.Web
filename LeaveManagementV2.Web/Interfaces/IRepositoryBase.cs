namespace LeaveManagementV2.Web.Interfaces
{
    public interface IRepositoryBase<T> where T: class
    {
        Task<T?> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
    }
}
