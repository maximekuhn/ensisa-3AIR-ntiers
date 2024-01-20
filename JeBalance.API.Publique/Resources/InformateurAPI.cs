using System.Net.Sockets;
using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class InformateurAPI
{
    [JsonPropertyName("nom")]
    public string Nom { get; set; }
    
    [JsonPropertyName("prenom")]
    public string Prenom { get; set; }
    [JsonPropertyName("adresse")]
    public AdresseAPI Adresse { get; set; }

    public InformateurAPI(Informateur source)
    {
        Nom = source.Nom;
        Prenom = source.Prenom;
        Adresse = new AdresseAPI(source.Adresse);
    }
}