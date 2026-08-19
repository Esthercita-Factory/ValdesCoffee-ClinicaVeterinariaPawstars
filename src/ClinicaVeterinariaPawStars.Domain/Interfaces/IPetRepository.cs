using ClinicaVeterinariaPawStars.Domain.Entities;

namespace ClinicaVeterinariaPawStars.Domain.Interfaces;

public interface IPetRepository
{
    IEnumerable<Pet> GetAll();

    Pet? GetByUuid(string uuid);

    void Add(Pet pet);

    bool Delete(string uuid);
}
