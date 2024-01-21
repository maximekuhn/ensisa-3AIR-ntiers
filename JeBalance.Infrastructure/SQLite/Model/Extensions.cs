using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.SQLite.Model;

public static class Extensions
{
    public static DenonciationSQLite ToSQLite(this Denonciation denonciation)
    {
        return new DenonciationSQLite
        {
            Id = denonciation.Id,
            TypeDelit = denonciation.TypeDelit,
            PaysEvasion = denonciation.PaysEvasion,
            Horodatage = denonciation.Horodatage,
            IdInformateur = denonciation.InformateurId,
            IdSuspect = denonciation.SuspectId
        };
    }

    public static Denonciation ToDomain(this DenonciationSQLite denonciation)
    {
        return new Denonciation
        {
            Id = denonciation.Id,
            InformateurId = denonciation.IdInformateur,
            SuspectId = denonciation.IdSuspect,
            Horodatage = denonciation.Horodatage,
            PaysEvasion = denonciation.PaysEvasion,
            ReponseId = denonciation.ReponseId,
            TypeDelit = denonciation.TypeDelit
        };
    }

    public static InformateurSQLite ToSQLite(this Informateur informateur)
    {
        return new InformateurSQLite
        {
            Id = informateur.Id,
            Nom = informateur.Nom.Value,
            Prenom = informateur.Prenom.Value,
            Adresse = informateur.Adresse
        };
    }

    public static SuspectSQLite ToSQLite(this Suspect suspect)
    {
        return new SuspectSQLite
        {
            Id = suspect.Id,
            Nom = suspect.Nom.Value,
            Prenom = suspect.Prenom.Value,
            Adresse = suspect.Adresse
        };
    }

    public static Suspect ToDomain(this SuspectSQLite suspect)
    {
        return new Suspect(new Nom(suspect.Nom), new Nom(suspect.Prenom), suspect.Adresse, suspect.Id);
    }

    public static Informateur ToDomain(this InformateurSQLite informateur)
    {
        return new Informateur(informateur.Id, new Nom(informateur.Nom), new Nom(informateur.Prenom),
            informateur.Adresse,
            informateur.EstCalomniateur);
    }

    public static ReponseSQLite ToSQLite(this Reponse reponse)
    {
        return new ReponseSQLite
        {
            Id = reponse.Id,
            TypeReponse = reponse.TypeReponse,
            Horodatage = reponse.Horodatage,
            Retribution = reponse.Retribution
        };
    }

    public static VIPsQLite ToSQLite(this VIP vip)
    {
        return new VIPsQLite()
        {
            Id = vip.Id,
            Nom = vip.Nom.Value,
            Prenom = vip.Prenom.Value,
            Adresse = vip.Adresse
        };
    }

    public static VIP ToDomain(this VIPsQLite vip)
    {
        return new VIP(new Nom(vip.Nom), new Nom(vip.Prenom), vip.Adresse, vip.Id);
    }
}