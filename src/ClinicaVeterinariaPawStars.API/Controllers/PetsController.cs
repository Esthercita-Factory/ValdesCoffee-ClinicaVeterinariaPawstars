using ClinicaVeterinariaPawStars.API.Models;
using ClinicaVeterinariaPawStars.Application.Interfaces;
using ClinicaVeterinariaPawStars.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinariaPawStars.API.Controllers;

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
    public IActionResult GetByUuid(string uuid)
    {
        var pet = _petService.GetByUuid(uuid);

        return pet == null
            ? NotFound()
            : Ok(pet);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePetRequest request)
    {
        Pet pet;
        try
        {
            pet = new Pet(
                request.Name,
                request.Species,
                request.Breed,
                request.Age,
                request.Weight,
                request.Symptoms,
                request.OwnerDocumentNumber,
                request.OwnerUuid
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

        _petService.Create(pet);

        return CreatedAtAction(
            nameof(GetByUuid),
            new { uuid = pet.Uuid },
            pet
        );
    }

    [HttpDelete("{uuid}")]
    public IActionResult Delete(string uuid)
    {
        var deleted = _petService.Delete(uuid);

        return deleted
            ? NoContent()
            : NotFound();
    }
}
