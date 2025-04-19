namespace TeamDebugger.Services
{
    public enum ErrorCode
    {
        Success, Error, Duplicate
    }
    public interface IBaseRepository<T>
    {
        T Get(object id);
        List<T> GetAll();
        ErrorCode Add(T entity);
        ErrorCode Update(object id, T entity);
        ErrorCode Delete(object id);

    }
}
