using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrzetwarzanieObrazow.Web.Pages;

public class Result : PageModel
{
	public string ResultString { get; set; }
    
	public void OnGet(string result)
	{
		ResultString = result;
	}
}