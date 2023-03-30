using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrzetwarzanieObrazow.Web.Pages;

using DTOs;

public class Result : PageModel
{
	public ImageDataObject ImageResult { get; set; }
    
	public void OnGet(ImageDataObject result)
	{
		ImageResult = result;
	}
}