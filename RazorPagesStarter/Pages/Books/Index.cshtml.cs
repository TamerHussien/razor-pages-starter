using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesStarter.Pages.Books
{
    public class IndexModel : PageModel
    {
        public static List<string> Books = new(); // in-memory store

    [TempData]
    public string? Message { get; set; }

    public List<string> BookList => Books;

    public IActionResult OnPostDelete(string title)
    {
        Books.Remove(title);
        Message = $"Deleted '{title}'";
        return RedirectToPage("/Books/Index");
    }
    }
}
