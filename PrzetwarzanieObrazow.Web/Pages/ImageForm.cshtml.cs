using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrzetwarzanieObrazow.Web.Pages;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Requests;

public class ImageForm : PageModel
{
	// How to load file as Bitmap:
	// https://blog.elmah.io/upload-and-resize-an-image-natively-with-asp-net-core/
	public async Task Process(ImageProcessingRequest req)
	{
		// Hardcoded to HighPassImageFilter for now.
		using (var client = new HttpClient())
		{
			var response = await client.PostAsJsonAsync("https://localhost:7062/api/Processing/HighPassFilter", req);
			
			// Display result.
			// resultLabel.Text = response;
		}
	}
}