using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciation;

public class CreateDenonciationCommand : IRequest<Guid>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string? paysEvasion, Informateur informateur, Suspect suspect)
    {
        Denonciation = new Model.Denonciation(typeDelit, paysEvasion, 0, 0);
        Informateur = informateur;
        Suspect = suspect;
    }

    public Model.Denonciation Denonciation { get; }
    public Informateur Informateur { get; }
    public Suspect Suspect { get; }
}