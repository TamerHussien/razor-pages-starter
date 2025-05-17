using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesStarter.Pages
{
    public class AboutModel : PageModel
    { [TempData]
    public string? Message { get; set; }
    public void OnGet()
    {
            // Initialize the page for GET requests
    }
    public void OnPost()
    {
        Message = "🚀 This message came from TempData via POST!";
        Response.Redirect("/Index");
    }
    }
}