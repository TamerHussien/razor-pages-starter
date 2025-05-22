using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesStarter.Data;
using RazorPagesStarter.Models;
namespace RazorPagesStarter.Pages.Books
{
   public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db) => _db = db;

    public List<Book> BookList { get; set; } = [];

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Sort { get; set; }

    [TempData]
    public string? Message { get; set; }

    public async Task OnGetAsync()
    {
        var query = _db.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
            query = query.Where(b => b.Title!.Contains(Search));

        query = Sort == "desc"
            ? query.OrderByDescending(b => b.Title)
            : query.OrderBy(b => b.Title);

        BookList = await query.AsNoTracking().ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book is not null)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            Message = $"Deleted '{book.Title}'";
        }
        return RedirectToPage("/Books/Index");
    }
}

}
