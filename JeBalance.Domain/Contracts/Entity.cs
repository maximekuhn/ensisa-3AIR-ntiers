namespace JeBalance.Domain.Contracts;

public abstract class Entity
{
    public Entity(int id)
    {
        Id = id;
    }

    public int Id { get; }
}