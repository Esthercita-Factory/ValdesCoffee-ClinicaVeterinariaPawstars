using System.Text.Json.Serialization;

namespace ClinicaVeterinariaPawStars.Domain.Entities;

public class Pet : EntityBase
{
    [JsonPropertyName("name")]
    public string Name { get; private set; } = string.Empty;

    [JsonPropertyName("species")]
    public string Species { get; private set; } = string.Empty;

    [JsonPropertyName("breed")]
    public string Breed { get; private set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; private set; }

    [JsonPropertyName("weight")]
    public double Weight { get; private set; }

    [JsonPropertyName("symptoms")]
    public string Symptoms { get; private set; } = string.Empty;

    [JsonPropertyName("owner_document_number")]
    public string OwnerDocumentNumber { get; private set; } = string.Empty;

    [JsonPropertyName("owner_uuid")]
    public string OwnerUuid { get; private set; } = string.Empty;

    public Pet(string name, string species, string breed, int age, double weight, string symptoms, string ownerDocumentNumber, string ownerUuid = "")
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la mascota es obligatorio.", nameof(name));

        if (string.IsNullOrWhiteSpace(species))
            throw new ArgumentException("La especie de la mascota es obligatoria.", nameof(species));

        if (age < 0)
            throw new ArgumentOutOfRangeException(nameof(age), "La edad no puede ser negativa.");

        if (weight <= 0)
            throw new ArgumentOutOfRangeException(nameof(weight), "El peso debe ser mayor a cero.");

        Name = name;
        Species = species;
        Breed = breed;
        Age = age;
        Weight = weight;
        Symptoms = symptoms;
        OwnerDocumentNumber = ownerDocumentNumber;
        OwnerUuid = ownerUuid;
    }

    public void UpdateWeight(double weight)
    {
        if (weight <= 0)
            throw new ArgumentOutOfRangeException(nameof(weight), "El peso debe ser mayor a cero.");

        Weight = weight;
    }

    public void RegisterSymptoms(string symptoms)
    {
        Symptoms = symptoms ?? string.Empty;
    }

    public void AssignOwner(string ownerUuid)
    {
        if (string.IsNullOrWhiteSpace(ownerUuid))
            throw new ArgumentException("El uuid del propietario es obligatorio.", nameof(ownerUuid));

        OwnerUuid = ownerUuid;
    }
}
