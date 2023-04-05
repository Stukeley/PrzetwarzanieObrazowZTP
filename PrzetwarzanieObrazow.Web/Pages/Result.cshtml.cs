using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrzetwarzanieObrazow.Web.Pages;

using DTOs;

public class Result : PageModel
{
	public static ImageDataObject ImageResult { get; set; }
	public ImageDataObject CurrentImageResult { get; set; }
    
	public void OnGet()
	{
		CurrentImageResult = ImageResult;
	}
}