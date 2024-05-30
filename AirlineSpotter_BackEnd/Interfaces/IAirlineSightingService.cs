using AirlineSpotter.Models;

namespace AirlineSpotter.Interfaces;

public interface IAirlineSightingService
{
    Task<IEnumerable<AirlineSighting>> GetAirlineSightingsAsync();
    Task<AirlineSighting> GetAirlineSightingAsync(int id);
    Task<AirlineSighting> AddAirlineSightingAsync(AirlineSighting sighting);
    Task<AirlineSighting> UpdateAirlineSightingAsync(int id, AirlineSighting sighting);
    Task<bool> DeleteAirlineSightingAsync(int id);
}