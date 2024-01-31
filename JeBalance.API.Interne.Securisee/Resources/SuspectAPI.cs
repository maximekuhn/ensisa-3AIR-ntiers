using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Interne.Securisee.Resources;

public class SuspectAPI
{
    public SuspectAPI()
    {
        Adresse = new AdresseAPI();
    }

    public SuspectAPI(Suspect source)
    {
        Nom = source.Nom;
        Prenom = source.Prenom;
        Adresse = new AdresseAPI(source.Adresse);
    }

    [JsonPropertyName("nom")] public string Nom { get; set; }

    [JsonPropertyName("prenom")] public string Prenom { get; set; }

    [JsonPropertyName("adresse")] public AdresseAPI Adresse { get; set; }
}