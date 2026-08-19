using ClinicaVeterinariaPawStars.Application.Interfaces;
using ClinicaVeterinariaPawStars.Domain.Entities;
using ClinicaVeterinariaPawStars.Domain.Interfaces;

namespace ClinicaVeterinariaPawStars.Application.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public IEnumerable<Pet> GetAll() => _petRepository.GetAll();

    public Pet? GetByUuid(string uuid) => _petRepository.GetByUuid(uuid);

    public Pet Create(Pet pet)
    {
        _petRepository.Add(pet);
        return pet;
    }

    public bool Delete(string uuid) => _petRepository.Delete(uuid);
}
