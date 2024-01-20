using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Architecture.SQLite.Model;

public static class Extensions
{
    private static readonly char AdresseSep = '$';

    public static DenonciationSQLite ToSQLite(this Denonciation denonciation)
    {
        return new DenonciationSQLite
        {
            Id = denonciation.Id,
            TypeDelit = denonciation.TypeDelit,
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
            Adresse = informateur.Adresse.ToSQLite()
        };
    }

    public static SuspectSQLite ToSQLite(this Suspect suspect)
    {
        return new SuspectSQLite
        {
            Id = suspect.Id,
            Nom = suspect.Nom.Value,
            Prenom = suspect.Prenom.Value,
            Adresse = suspect.Adresse.ToSQLite()
        };
    }

    public static Suspect ToDomain(this SuspectSQLite suspect)
    {
        return new Suspect(new Nom(suspect.Nom), new Nom(suspect.Prenom), suspect.Adresse.ToDomain(), suspect.Id);
    }

    public static Informateur ToDomain(this InformateurSQLite informateur)
    {
        return new Informateur(new Nom(informateur.Nom), new Nom(informateur.Prenom), informateur.Adresse.ToDomain(), informateur.Id);
    }

    private static string ToSQLite(this Adresse adresse)
    {
        return
            $"{adresse.NumeroVoieDeVoie.Value}{AdresseSep}{adresse.NomVoie.Value}{AdresseSep}{adresse.NomCommune.Value}{AdresseSep}{adresse.CodePostal.Value}";
    }

    private static Adresse ToDomain(this string adresseStr)
    {
        var fragments = adresseStr.Split(AdresseSep);
        if (fragments.Length != 4) throw new ApplicationException("Could not retrieve address");
        var numeroDeVoie = int.Parse(fragments[0]);
        var codePostal = int.Parse(fragments[3]);
        return new Adresse(new NumeroVoie(numeroDeVoie), new NomVoie(fragments[1]), new CodePostal(codePostal),
            new NomCommune(fragments[2]));
    }
}