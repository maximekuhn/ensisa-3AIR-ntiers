using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreerDenonciationCommande : IRequest<int>
{
    public Denonciation Denonciation { get; }

    public CreerDenonciationCommande(TypeDelit typeDelit, string paysEvasion)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion);
    }
}