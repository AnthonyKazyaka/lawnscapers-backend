namespace Lawnscapers.DataStorage
{
    public interface IDataMapper<T, U> where T : class where U : class
    {
        U Map(T data);
        T Map(U data);
    }
}
