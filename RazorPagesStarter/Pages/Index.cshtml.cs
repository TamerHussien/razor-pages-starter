using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesStarter.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50,MinimumLength = 2 ,ErrorMessage = "Name must be 2-50 characters.")]
    public string? UserName { get; set; }

    public string? Greeting { get; set; }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        Greeting = $"Hello, {UserName}!";
    }
}