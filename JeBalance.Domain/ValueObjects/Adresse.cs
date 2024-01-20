namespace JeBalance.Domain.ValueObjects;

public class Adresse
{
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

    // TODO: comparator

}