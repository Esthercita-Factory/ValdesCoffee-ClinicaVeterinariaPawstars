namespace ClinicaVeterinariaPawStars.Domain.Entities;

public abstract class EntityBase
{
    public string Uuid { get; private set; } = Guid.NewGuid().ToString();

    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
