using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommand : IRequest<int>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string paysEvasion, int informateurId, int suspectId)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion, informateurId, suspectId);
    }

    public Denonciation Denonciation { get; }
}