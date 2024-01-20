namespace JeBalance.Domain.ValueObjects;

public class Adresse
{
    public const char ADRESSE_SEPARATOR = '$';

    public Adresse(NumeroVoie numeroVoieDeVoie, NomVoie nomVoie, CodePostal codePostal, NomCommune nomCommune)
    {
        NumeroVoieDeVoie = numeroVoieDeVoie;
        NomVoie = nomVoie;
        CodePostal = codePostal;
        NomCommune = nomCommune;
    }

    public NumeroVoie NumeroVoieDeVoie { get; set; }
    public NomVoie NomVoie { get; set; }
    public CodePostal CodePostal { get; set; }
    public NomCommune NomCommune { get; set; }

    public override string ToString()
    {
        return
            $"{NumeroVoieDeVoie.Value}{ADRESSE_SEPARATOR}{NomVoie.Value}{ADRESSE_SEPARATOR}{CodePostal.Value}{ADRESSE_SEPARATOR}{NomCommune.Value}";
    }

    private static Adresse fromString(string adresseStr)
    {
        var fragments = adresseStr.Split(ADRESSE_SEPARATOR);
        if (fragments.Length != 4) throw new ApplicationException("Could not retrieve address");
        var numeroDeVoie = int.Parse(fragments[0]);
        var codePostal = int.Parse(fragments[2]);
        return new Adresse(new NumeroVoie(numeroDeVoie), new NomVoie(fragments[1]), new CodePostal(codePostal),
            new NomCommune(fragments[3]));
    }

    public static implicit operator string(Adresse adresse)
    {
        return adresse.ToString();
    }

    public static implicit operator Adresse(string adressStr)
    {
        return fromString(adressStr);
    }
}