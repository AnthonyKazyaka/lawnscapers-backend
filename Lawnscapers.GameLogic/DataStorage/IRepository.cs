namespace Lawnscapers.DataStorage
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string? collectionName = null);
        Task<T> GetByIdAsync(Guid id, string? collectionName = null);
        Task AddAsync(T entity, string? collectionName = null);
        Task UpdateAsync(T entity, string? collectionName = null);
        Task DeleteAsync(Guid id, string? collectionName = null);
    }
}
