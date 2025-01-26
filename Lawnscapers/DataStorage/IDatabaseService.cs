namespace Lawnscapers.DataStorage
{
    public interface IDatabaseService
    {
        Task<T> GetAsync<T>(string collectionName, string key, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAllAsync<T>(string collectionName, CancellationToken cancellationToken = default);

        Task SubmitAsync<T>(string collectionName, string key, T data, CancellationToken cancellationToken = default);

        Task DeleteAsync(string collectionName, string key, CancellationToken cancellationToken = default);
    }
}
