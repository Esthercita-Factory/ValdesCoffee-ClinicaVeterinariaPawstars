using System.Collections.Concurrent;
using ClinicaVeterinariaPawStars.Domain.Entities;
using ClinicaVeterinariaPawStars.Domain.Interfaces;

namespace ClinicaVeterinariaPawStars.Infrastructure.Repositories;

public class InMemoryPetRepository : IPetRepository
{
    private readonly ConcurrentDictionary<string, Pet> _pets = new();

    public IEnumerable<Pet> GetAll() => _pets.Values;

    public Pet? GetByUuid(string uuid) => _pets.GetValueOrDefault(uuid);

    public void Add(Pet pet) => _pets[pet.Uuid] = pet;

    public bool Delete(string uuid) => _pets.TryRemove(uuid, out _);
}
