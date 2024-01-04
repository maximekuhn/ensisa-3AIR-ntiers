using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public static class Extensions
{
    public static DenonciationSQLite ToSQLite(this Denonciation denonciation)
    {
        return new DenonciationSQLite
        {
            Id = denonciation.Id,
            // TODO
            NomInformateur = "Albi",
        };
    }
}