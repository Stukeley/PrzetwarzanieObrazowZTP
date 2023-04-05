using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrzetwarzanieObrazow.Web.Pages;

using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class ImageForm : PageModel
{
	public async Task<IActionResult> OnPostAsync(IFormFile fileUpload)
	{
		Bitmap bitmap;

		using (var memoryStream = new MemoryStream())
		{
			await fileUpload.CopyToAsync(memoryStream);
			byte[] fileBytes = memoryStream.ToArray();

			bitmap = new Bitmap(new MemoryStream(fileBytes));
		}

		var dto = new ImageDataObject()
		{
			Width = bitmap.Width,
			Height = bitmap.Height,
			Algorithm = "highpass"
		};
		
		using (var memoryStream = new MemoryStream())
		{
			bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
			dto.Data = memoryStream.ToArray();
		}

		using (var client = new HttpClient())
		{
			// Send the DTO to the API.
			var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5089/api/gateway", content);
			
			var resultString = await response.Content.ReadAsStringAsync();
			var resultParsed = System.Text.Json.JsonSerializer.Deserialize<ImageDataObject>(resultString);
			
			Result.ImageResult = resultParsed;
			return Redirect("/result");
		}
	}
}