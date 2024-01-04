using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommand : IRequest<int>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string paysEvasion, Informateur informateur, Suspect suspect)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion, informateur, suspect);
    }

    public Denonciation Denonciation { get; }
}