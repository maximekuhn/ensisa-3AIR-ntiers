using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Interne.Securisee.Resources;

public class DenonciationAPI
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("typeDelit")]
    public TypeDelit TypeDelit { get; set; }
    
    [JsonPropertyName("paysEvasion")]
    public string? PaysEvasion { get; set; }
    
    [JsonPropertyName("horodatage")]
    public DateTime Horodatage { get; set; }
    
    [JsonPropertyName("informateurId")]
    public int InformateurId { get; set; }
    
    [JsonPropertyName("suspectId")]
    public int SuspectId { get; set; }
    
    [JsonPropertyName("reponseId")]
    public int? ReponseId { get; set; }
    
    public DenonciationAPI(Denonciation denonciation)
    {
        Id = denonciation.Id;
        TypeDelit = denonciation.TypeDelit;
        PaysEvasion = denonciation.PaysEvasion;
        Horodatage = denonciation.Horodatage;
        InformateurId = denonciation.InformateurId;
        SuspectId = denonciation.SuspectId;
        ReponseId = denonciation.ReponseId;
    }
}