namespace Lawnscapers.GameLogic.DataStorage
{
    public interface IDatabaseService<T>
    {
        Task<IEnumerable<T>> GetData(string keyName);
        Task SubmitData(string key, T data);
    }
}
