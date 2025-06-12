using System.ComponentModel.DataAnnotations;

namespace MobilidadeAPI.Models;

public class Transport
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Type is required.")]
    public string Type { get; set; } = string.Empty;

    [Required(ErrorMessage = "User is required.")]
    public string User { get; set; } = string.Empty;

    public DateTime UsageDate { get; set; }
}
