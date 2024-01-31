using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

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
        if (typeReponse.Equals(TypeReponse.Confirmation) && retribution == null)
            throw new ApplicationException(
                "Une réponse de type confirmation doit obligatoirement avoir une retribution");

        TypeReponse = typeReponse;
        Retribution = retribution;
    }

    public TypeReponse TypeReponse { get; set; }
    public double? Retribution { get; set; }
    public DateTime Horodatage { get; set; }
}