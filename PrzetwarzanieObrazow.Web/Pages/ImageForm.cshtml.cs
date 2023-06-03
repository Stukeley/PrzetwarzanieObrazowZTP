using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrzetwarzanieObrazow.Web.Pages;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
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

		string algorithm = Request.Form["algorithm"];

		var dto = new ImageDataObject()
		{
			Width = bitmap.Width,
			Height = bitmap.Height,
			Algorithm = algorithm
		};
		
		var bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
		int numbytes = bmpdata.Width * bitmap.Height * 3;
		byte[] bytedata = new byte[numbytes];
		var ptr = bmpdata.Scan0;

		Marshal.Copy(ptr, bytedata, 0, numbytes);

		bitmap.UnlockBits(bmpdata);
		
		dto.Data = bytedata;

		using (var client = new HttpClient())
		{
			// Send the DTO to the API.
			var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5089/api/gateway", content);
			
			var resultString = await response.Content.ReadAsStringAsync();
			var resultParsed = System.Text.Json.JsonSerializer.Deserialize<ImageDataObject>(resultString);
			
			// Rekonstrukcja nagłówka.
			var resultBitmap = new Bitmap(dto.Width,dto.Height,PixelFormat.Format24bppRgb);
			var resultBmpData = resultBitmap.LockBits(new Rectangle(0, 0, dto.Width, dto.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			var resultPtr = resultBmpData.Scan0;
			Marshal.Copy(resultParsed.Data, 0, resultPtr, dto.Width * dto.Height * 3);
			
			resultBitmap.UnlockBits(resultBmpData);

			using (var ms = new MemoryStream())
			{
				resultBitmap.Save(ms, ImageFormat.Png);
				resultParsed.Data = ms.ToArray();
			}
			
			Result.ImageResult = resultParsed;
			return Redirect("/result");
		}
	}
}