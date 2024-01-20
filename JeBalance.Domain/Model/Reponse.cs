using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

// TODO

public class Reponse : Entity<int>
{
    public Reponse(int id) : base(id)
    {
    }

    public Reponse() : base(0)
    {
    }
}