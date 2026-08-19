using Microsoft.AspNetCore.Mvc;
using ClinicaVeterinariaPawStars.Domain.Entities;
using ClinicaVeterinariaPawStars.Domain.Interfaces;
public class PetsController : Controller
{
    private readonly IPetService _petService;
}
namespace ClinicaVeterinariaPawStars.Domain.Interfaces
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_petService.GetAll());
        }

        [HttpGet("{uuid}")]
        public IActionResult GetByUid(string uuid)
        {
            var pet = _petService.GetByUuid(uuid);

            return pet == null
                ? NotFound()
                : Ok(pet);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pet pet)
        {
            _petService.Create(pet);

            return CreatedAtAction(
                nameof(GetByUid),
                new { uuid = pet.Uuid },
                pet
            );
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            _petService.Delete(uuid);

            return NoContent();
        }
    }
}