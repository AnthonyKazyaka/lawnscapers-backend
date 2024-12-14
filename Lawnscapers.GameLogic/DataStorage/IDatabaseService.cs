namespace Lawnscapers.GameLogic.DataStorage
{
    public interface IDatabaseService<T>
    {
        Task<IEnumerable<T>> GetData(string collectionName);
        Task SubmitData(string collectionName, string key, T data);
        Task DeleteData(string collectionName, string key);
    }
}
