using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommand : IRequest<int>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string paysEvasion)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion);
    }

    public Denonciation Denonciation { get; }
}