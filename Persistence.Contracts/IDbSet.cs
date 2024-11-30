namespace Persistence.Contracts;

public interface IDbSet<T> : IQueryable<T>, IAsyncEnumerable<T>
{
    void Add(T entity);
}