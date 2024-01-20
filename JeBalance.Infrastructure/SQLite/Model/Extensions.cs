using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public static class Extensions
{
    public static DenonciationSQLite ToSQLite(this Denonciation denonciation)
    {
        return new DenonciationSQLite
        {
            Id = denonciation.Id,
            TypeDelit = TypeDelit.DissimulationDeRevenus,
            Horodatage = denonciation.Horodatage,
            IdInformateur = denonciation.InformateurId,
            IdSuspect = denonciation.SuspectId
        };
    }

    public static InformateurSQLite ToSQLite(this Informateur informateur)
    {
        return new InformateurSQLite
        {
            Id = informateur.Id,
            Nom = informateur.Nom.Value,
            Prenom = informateur.Prenom.Value,
            Adresse = "todo"
        };
    }

    public static SuspectSQLite ToSQLite(this Suspect suspect)
    {
        return new SuspectSQLite
        {
            Id = suspect.Id,
            Nom = suspect.Nom.Value,
            Prenom = suspect.Prenom.Value,
            Adresse = "todo"
        };
    }

    public static Suspect ToDomain(this SuspectSQLite suspect)
    {
        return new Suspect();
    }

    public static Informateur ToDomain(this InformateurSQLite informateur)
    {
        return new Informateur();
    }
}