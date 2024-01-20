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

    public Reponse(TypeReponse typeReponse, double? retribution) : base(0)
    {
        TypeReponse = typeReponse;
        Retribution = retribution;
    }

    public TypeReponse TypeReponse { get; set; }
    public double? Retribution { get; set; }
    public DateTime Horodatage { get; set; }
}