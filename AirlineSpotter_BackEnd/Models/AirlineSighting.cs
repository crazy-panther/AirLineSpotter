namespace AirlineSpotter.Models;

public class AirlineSighting
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string AirlineCode { get; set; }
    public string Location { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Active { get; set; }
    public bool Delete { get; set; }
    public int CreatedUserId { get; set; }
    public int ModifiedUserId { get; set; }
}