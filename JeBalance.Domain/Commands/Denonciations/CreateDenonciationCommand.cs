using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands.Denonciations;

public class CreateDenonciationCommand : IRequest<Guid>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string? paysEvasion, Informateur informateur, Suspect suspect)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion, 0, 0);
        Informateur = informateur;
        Suspect = suspect;
    }

    public Denonciation Denonciation { get; }
    public Informateur Informateur { get; }
    public Suspect Suspect { get; }
}