using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesStarter.Pages.Books
{
    public class AddModel : PageModel
    {
    [BindProperty]
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        IndexModel.Books.Add(Title!);
        TempData["Message"] = $"Added '{Title}'";
        return RedirectToPage("/Books/Index");
    }
    }
}
