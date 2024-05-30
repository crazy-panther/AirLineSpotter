using AirlineSpotter.Models;
using Microsoft.EntityFrameworkCore;

public class AirlineSpotterDbContext : DbContext
{
    public AirlineSpotterDbContext(DbContextOptions<AirlineSpotterDbContext> options) : base(options) { }

    public DbSet<AirlineSighting> AirlineSightings { get; set; }
}