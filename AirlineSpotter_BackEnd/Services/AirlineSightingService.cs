using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirlineSpotter.Interfaces;
using AirlineSpotter.Models;

public class AirlineSightingService : IAirlineSightingService
{
    private readonly AirlineSpotterDbContext _context;

    public AirlineSightingService(AirlineSpotterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AirlineSighting>> GetAirlineSightingsAsync()
    {
        return await _context.AirlineSightings.ToListAsync();
    }

    public async Task<AirlineSighting> GetAirlineSightingAsync(int id)
    {
        return await _context.AirlineSightings.FindAsync(id);
    }

    public async Task<AirlineSighting> AddAirlineSightingAsync(AirlineSighting sighting)
    {
        _context.AirlineSightings.Add(sighting);
        await _context.SaveChangesAsync();
        return sighting;
    }

    public async Task<AirlineSighting> UpdateAirlineSightingAsync(int id, AirlineSighting sighting)
    {
        if (id != sighting.Id)
        {
            return null;
        }

        _context.Entry(sighting).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await AirlineSightingExistsAsync(id))
            {
                return null;
            }
            else
            {
                throw;
            }
        }
        return sighting;
    }

    public async Task<bool> DeleteAirlineSightingAsync(int id)
    {
        var sighting = await _context.AirlineSightings.FindAsync(id);
        if (sighting == null)
        {
            return false;
        }

        _context.AirlineSightings.Remove(sighting);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<bool> AirlineSightingExistsAsync(int id)
    {
        return await _context.AirlineSightings.AnyAsync(e => e.Id == id);
    }
}