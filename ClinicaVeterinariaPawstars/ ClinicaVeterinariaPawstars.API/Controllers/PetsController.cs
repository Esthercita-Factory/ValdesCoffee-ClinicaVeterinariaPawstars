using Microsoft.AspNetCore.Mvc; 
using ClinicaVeterinariaPawstars.Models;
// Asumimos que tienes una carpeta Services
using ClinicaVeterinariaPawstars.Services; 

namespace ClinicaVeterinariaPawstars.Controllers;

[ApiController]
// TRUCO: Usa [controller] entre corchetes para que C# tome el nombre de la clase (Pets) automáticamente
[Route("api/[controller]")] 
public class PetsController : ControllerBase
{
    // 1. Corrección: 'readonly' (con 'a') y debe ser del tipo de la Interfaz
    private readonly IPetService _petService;

    // 2. Corrección: El constructor asigna la interfaz al campo privado
    public PetsController(IPetService petService)
    {
        _petService = petService;
    }
    
    [HttpGet] 
    // 3. Corrección: 'IActionResult' (todo pegado)
    public IActionResult GetAll() => Ok(_petService.GetAll());

    // 4. Corrección: El nombre en la ruta {uuid} debe ser igual al del parámetro
    [HttpGet("{uuid}")] 
    public IActionResult GetByUid(string uuid) 
    { 
        var pet = _petService.GetByUuid(uuid);
        return pet == null ? NotFound() : Ok(pet); 
    }

    [HttpPost] 
    public IActionResult Create([FromBody] Pet pet) 
    { 
        _petService.Create(pet);
        return CreatedAtAction(nameof(GetByUid), new { uuid = "generado-id" }, pet);
    }

    [HttpDelete("{uuid}")] 
    // 5. Corrección: 'IActionResult' con 'A' mayúscula
    public IActionResult Delete(string uuid) 
    { 
        _petService.Delete(uuid);
        return NoContent(); 
    }
}