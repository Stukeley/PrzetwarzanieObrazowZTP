namespace PrzetwarzanieObrazow.API.Controllers;

using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Code.Builders;
using Code.Helpers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

[Route("api/algorithms")]
[ApiController]
public class AlgorithmsController : ControllerBase
{
	[HttpPost]
	[Route("highpass")]
	public async Task<IActionResult> Highpass([FromBody] ImageDataObject obj)
	{
		if (obj?.Data == null)
		{
			return NoContent();
		}

		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var highPassAlgorithm = new ImageFilterBuilder().BuildHighPassFilterAlgorithm(bitmap);
		var output = highPassAlgorithm.Process();

		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, output.Width, output.Height);

		return Ok(outputString);
	}

	[HttpPost]
	[Route("grayscale")]
	public async Task<IActionResult> Grayscale([FromBody] ImageDataObject obj)
	{
		if (obj?.Data == null)
		{
			return NoContent();
		}

		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var grayscaleAlgorithm = new ImageFilterBuilder().BuildGrayscaleFilterAlgorithm(bitmap);
		var output = grayscaleAlgorithm.Process();

		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, output.Width, output.Height);

		return Ok(outputString);
	}

	[HttpPost]
	[Route("brightnesschange")]
	public async Task<IActionResult> BrightnessChange([FromBody] ImageDataObject obj)
	{
		if (obj?.Data == null)
		{
			return NoContent();
		}

		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var grayscaleAlgorithm = new ImageFilterBuilder().BuildBrightnessChangeAlgorithm(bitmap);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, output.Width, output.Height);

		return Ok(outputString);
	}
	
	[HttpPost]
	[Route("contrastchange")]
	public async Task<IActionResult> ConstrastChange([FromBody] ImageDataObject obj)
	{
		if (obj?.Data == null)
		{
			return NoContent();
		}

		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var grayscaleAlgorithm = new ImageFilterBuilder().BuildContrastChangeAlgorithm(bitmap);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, output.Width, output.Height);

		return Ok(outputString);
	}
	
	[HttpPost]
	[Route("laplace")]
	public async Task<IActionResult> Laplace([FromBody] ImageDataObject obj)
	{
		if (obj?.Data == null)
		{
			return NoContent();
		}

		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var grayscaleAlgorithm = new ImageFilterBuilder().BuildLaplaceFilterAlgorithm(bitmap);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, output.Width, output.Height);

		return Ok(outputString);
	}
	
	[HttpPost]
	[Route("binary")]
	public async Task<IActionResult> Binary([FromBody] ImageDataObject obj)
	{
		if (obj?.Data == null)
		{
			return NoContent();
		}

		var bitmap = ImageDataToBitmap.ConvertImageDataToBitmap(obj);
		var grayscaleAlgorithm = new ImageFilterBuilder().BuildImageToBinaryAlgorithm(bitmap);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, output.Width, output.Height);

		return Ok(outputString);
	}

	private static async Task<string> ConvertAndReturnOutput(Bitmap outputBitmap, string algorithm, int width, int height)
	{
		var outputDto = new ImageDataObject()
		{
			Algorithm = algorithm,
			Width = width,
			Height = height
		};
		
		using (var memoryStream = new MemoryStream())
		{
			outputBitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
			outputDto.Data = memoryStream.ToArray();
		}

		string outputString = System.Text.Json.JsonSerializer.Serialize(outputDto);

		return outputString;
	}
}