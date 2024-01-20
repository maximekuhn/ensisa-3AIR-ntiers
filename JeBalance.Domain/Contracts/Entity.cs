namespace JeBalance.Domain.Contracts;

public abstract class Entity<T>
{
    public Entity(T id)
    {
        Id = id;
    }

    public T Id { get; set; }
}