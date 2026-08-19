using System.Text.Json.Serialization;

namespace ClinicaVeterinariaPawStars.API.Models;

public class CreatePetRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("species")]
    public string Species { get; set; } = string.Empty;

    [JsonPropertyName("breed")]
    public string Breed { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    [JsonPropertyName("symptoms")]
    public string Symptoms { get; set; } = string.Empty;

    [JsonPropertyName("owner_document_number")]
    public string OwnerDocumentNumber { get; set; } = string.Empty;

    [JsonPropertyName("owner_uuid")]
    public string OwnerUuid { get; set; } = string.Empty;
}
