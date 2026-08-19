using ClinicaVeterinariaPawStars.Domain.Entities;

namespace ClinicaVeterinariaPawStars.Application.Interfaces;

public interface IPetService
{
    IEnumerable<Pet> GetAll();

    Pet? GetByUuid(string uuid);

    Pet Create(Pet pet);

    bool Delete(string uuid);
}
