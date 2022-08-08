namespace ApplicationCore.Contracts.Repository;

public interface IRepositoryAsync<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> InsertAsync(T entity);
    Task<int> DeleteAsync(int id);
}
