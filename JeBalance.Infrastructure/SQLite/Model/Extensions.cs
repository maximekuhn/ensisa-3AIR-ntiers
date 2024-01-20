using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

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
    
}