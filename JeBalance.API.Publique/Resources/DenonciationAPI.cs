using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class DenonciationAPI
{
    // Informations de la dénonciation
    public TypeDelit TypeDelit { get; set; }
    public string? PaysEvasion { get; set; }

    // Informations à propos du suspect
    public string NomSuspect { get; set; }
    public string PrenomSuspect { get; set; }


    // Informations à propos de l'informateur
    public string NomInformateur { get; set; }
    public string PrenomInformateur { get; set; }

    public DenonciationAPI()
    {
    }
}