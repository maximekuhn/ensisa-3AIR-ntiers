namespace JeBalance.Domain.Contracts;

public interface Repository<T, TKey> where T : Entity<TKey>
{
    public Task<IEnumerable<T>> Find(int limit, int offset, Specification<T> specification);
    public Task<T> GetOne(int id);
    public Task<TKey> Create(T T);
    public Task<TKey> Update(int id, T T);
    public Task<bool> Delete(int id);
}