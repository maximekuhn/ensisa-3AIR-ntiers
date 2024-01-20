using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommand : IRequest<Guid>
{
    public CreateDenonciationCommand(TypeDelit typeDelit, string? paysEvasion, string nomInformateur,
        string prenomInformateur, string nomSuspect, string prenomSuspect, int numeroVoieSuspect, string nomVoieSuspect,
        int codePostalSuspect, string nomCommuneSuspect, int numeroVoieInformateur, string nomVoieInformateur,
        int codePostalInformateur, string nomCommuneInformateur)
    {
        Denonciation = new Denonciation(typeDelit, paysEvasion, 0, 0);
        Informateur = new Informateur(nomInformateur, prenomInformateur);
        Suspect = new Suspect(prenomSuspect, nomSuspect);

        Informateur.Adresse = new Adresse(new NumeroVoie(numeroVoieInformateur), new NomVoie(nomVoieInformateur),
            new CodePostal(codePostalInformateur), new NomCommune(nomCommuneInformateur));

        Suspect.Adresse = new Adresse(new NumeroVoie(numeroVoieSuspect), new NomVoie(nomVoieSuspect),
            new CodePostal(codePostalSuspect), new NomCommune(nomCommuneSuspect));
    }

    public Denonciation Denonciation { get; }
    public Informateur Informateur { get; }
    public Suspect Suspect { get; }
}