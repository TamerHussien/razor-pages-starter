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

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public List<Book> BookList { get; set; } = [];

        [TempData]
        public string? Message { get; set; }

        public async Task OnGetAsync()
        {
            BookList = await _db.Books.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {

            Console.WriteLine($"Deleting book with ID: {id}");
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
