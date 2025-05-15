using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesStarter.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string? UserName { get; set; }

    public string? Greeting { get; set; }

    public void OnPost()
    {
        if (!string.IsNullOrWhiteSpace(UserName))
        {
            Greeting = $"Hello, {UserName}!";
        }
    }
}
