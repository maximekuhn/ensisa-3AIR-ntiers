using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommand : IRequest<int>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string? paysEvasion, string nomInformateur,
        string prenomInformateur, string nomSuspect, string prenomSuspect)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion, 0, 0);
        Informateur = new Informateur(nomInformateur, prenomInformateur);
        Suspect = new Suspect(prenomSuspect, nomSuspect);
    }

    public Denonciation Denonciation { get; }
    public Informateur Informateur { get; }
    public Suspect Suspect { get; }
}