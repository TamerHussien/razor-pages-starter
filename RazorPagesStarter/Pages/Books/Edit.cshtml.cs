using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesStarter.Data;
using RazorPagesStarter.Models;

namespace RazorPagesStarter.Pages.Books;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;

    public EditModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Book Book { get; set; } = new();

    [TempData]
    public string? Message { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book == null) return RedirectToPage("/Books/Index");

        Book = book;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _db.Attach(Book).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        Message = $"Updated '{Book.Title}'";
        return RedirectToPage("/Books/Index");
    }
}
