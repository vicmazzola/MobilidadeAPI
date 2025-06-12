namespace MobilidadeAPI.Models;

public class Transport
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty; // e.g., bike, scooter, etc.
    public string User { get; set; } = string.Empty;
    public DateTime UsageDate { get; set; }
}
