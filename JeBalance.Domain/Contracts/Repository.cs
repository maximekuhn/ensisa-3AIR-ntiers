namespace JeBalance.Domain.Contracts;

public interface Repository<T, TKey> where T : Entity<TKey>
{
    public Task<(IEnumerable<T> Results, int Total)> Find(int limit, int offset, Specification<T> specification);
    public Task<T> GetOne(TKey id);
    public Task<TKey> Create(T T);
    public Task<TKey> Update(TKey id, T T);
    public Task<bool> Delete(TKey id);
}