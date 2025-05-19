using System.ComponentModel.DataAnnotations;

namespace RazorPagesStarter.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
}