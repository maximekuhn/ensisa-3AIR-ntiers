using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public static class Extensions
{
    public static DenonciationSQLite ToSQLite(this Denonciation denonciation)
    {
        return new DenonciationSQLite
        {
            Id = denonciation.Id,
            TypeDelit = TypeDelit.DissimulationDeRevenus
            // TODO
        };
    }

    public static InformateurSQLite ToSQLite(this Informateur informateur)
    {
        return new InformateurSQLite
        {
            Id = informateur.Id
            // TODO
        };
    }

    public static SuspectSQLite ToSQLite(this Suspect suspect)
    {
        return new SuspectSQLite
        {
            Id = suspect.Id
        };
    }

    public static Suspect ToDomain(this SuspectSQLite suspect)
    {
        return new Suspect
        {

        };
    }

    public static Informateur ToDomain(this InformateurSQLite informateur)
    {
        return new Informateur
        {

        };
    }
}