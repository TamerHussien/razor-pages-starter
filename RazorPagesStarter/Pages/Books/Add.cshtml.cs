using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStarter.Data;
using RazorPagesStarter.Models;

namespace RazorPagesStarter.Pages.Books
{
    public class AddModel : PageModel
    {
    private readonly AppDbContext _db;

    public AddModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    [Required]
    [StringLength(100)]
    public string? Title { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _db.Books.Add(new Book { Title = Title! });
        await _db.SaveChangesAsync();

        TempData["Message"] = $"Added '{Title}'";
        return RedirectToPage("/Books/Index");
    }
    }
}
