using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirlineSpotter.Interfaces;
using AirlineSpotter.Models;

[Route("api/[controller]")]
[ApiController]
public class AirlineSightingsController : ControllerBase
{
    private readonly IAirlineSightingService _service;

    public AirlineSightingsController(IAirlineSightingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AirlineSighting>>> GetAirlineSightings()
    {
        var sightings = await _service.GetAirlineSightingsAsync();
        return Ok(sightings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AirlineSighting>> GetAirlineSighting(int id)
    {
        var sighting = await _service.GetAirlineSightingAsync(id);
        if (sighting == null)
        {
            return NotFound();
        }
        return Ok(sighting);
    }

    [HttpPost]
    public async Task<ActionResult<AirlineSighting>> PostAirlineSighting(AirlineSighting sighting)
    {
        var newSighting = await _service.AddAirlineSightingAsync(sighting);
        return CreatedAtAction(nameof(GetAirlineSighting), new { id = newSighting.Id }, newSighting);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAirlineSighting(int id, AirlineSighting sighting)
    {
        var updatedSighting = await _service.UpdateAirlineSightingAsync(id, sighting);
        if (updatedSighting == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirlineSighting(int id)
    {
        var success = await _service.DeleteAirlineSightingAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}