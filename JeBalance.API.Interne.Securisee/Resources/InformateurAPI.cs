using System.Text.Json.Serialization;
using JeBalance.API.Interne.Securisee.Resources;
using JeBalance.Domain.Model;

public class InformateurAPI
{
    public InformateurAPI()
    {
        Adresse = new AdresseAPI();
    }

    public InformateurAPI(Informateur source)
    {
        Nom = source.Nom;
        Prenom = source.Prenom;
        Adresse = new AdresseAPI(source.Adresse);
    }

    [JsonPropertyName("nom")] public string Nom { get; set; }

    [JsonPropertyName("prenom")] public string Prenom { get; set; }

    [JsonPropertyName("adresse")] public AdresseAPI Adresse { get; set; }
}