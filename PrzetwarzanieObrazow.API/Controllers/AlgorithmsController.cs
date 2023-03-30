namespace PrzetwarzanieObrazow.API.Controllers;

using System.IO;
using System.Threading.Tasks;
using Code.Builders;
using Code.Helpers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

[Route("api/algorithms")]
[ApiController]
public class AlgorithmsController: ControllerBase
{
	[HttpPost]
	[Route("highpass")]
	public async Task<IActionResult> Highpass([FromBody]ImageDataObject obj)
	{
		if (obj == null)
		{
			return NoContent();
		}
		
		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var highPassAlgorithm = new ImageFilterBuilder().BuildHighPassFilterAlgorithm(bitmap);
		var output = highPassAlgorithm.Process();

		var outputDto = new ImageDataObject()
		{
			Algorithm = obj.Algorithm,
			Width = output.Width,
			Height = output.Height
		};
		
		using (var memoryStream = new MemoryStream())
		{
			output.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
			outputDto.Data = memoryStream.ToArray();
		}

		var outputString = System.Text.Json.JsonSerializer.Serialize(outputDto);
		
		return Ok(outputString);
	}
	
	[HttpPost]
	[Route("grayscale")]
	public async Task<IActionResult> Grayscale()
	{
		return Ok("Grayscale");
	}
}