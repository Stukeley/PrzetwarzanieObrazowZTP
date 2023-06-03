namespace PrzetwarzanieObrazow.API.Controllers;

using System.Threading.Tasks;
using Code.Builders;
using Code.Models;
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
		
		var highPassAlgorithm = new ImageFilterBuilder().BuildHighPassFilterAlgorithm(obj);
		var output = highPassAlgorithm.Process();

		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, obj.Width, obj.Height);

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

		var grayscaleAlgorithm = new ImageFilterBuilder().BuildGrayscaleFilterAlgorithm(obj);
		var output = grayscaleAlgorithm.Process();

		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, obj.Width, obj.Height);

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

		var grayscaleAlgorithm = new ImageFilterBuilder().BuildBrightnessChangeAlgorithm(obj);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, obj.Width, obj.Height);

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

		var grayscaleAlgorithm = new ImageFilterBuilder().BuildContrastChangeAlgorithm(obj);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, obj.Width, obj.Height);

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

		var grayscaleAlgorithm = new ImageFilterBuilder().BuildLaplaceFilterAlgorithm(obj);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, obj.Width, obj.Height);

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

		var grayscaleAlgorithm = new ImageFilterBuilder().BuildImageToBinaryAlgorithm(obj);
		var output = grayscaleAlgorithm.Process();
		
		string outputString = await ConvertAndReturnOutput(output, obj.Algorithm, obj.Width, obj.Height);

		return Ok(outputString);
	}

	private static async Task<string> ConvertAndReturnOutput(Pixel[,] outputBytes, string algorithm, int width, int height)
	{
		var outputDto = new ImageDataObject()
		{
			Algorithm = algorithm,
			Width = width,
			Height = height
		};

		outputDto.Data = new byte[width * height * 3];
		
		int index = 0;

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				outputDto.Data[index] = outputBytes[x, y].R;
				outputDto.Data[index + 1] = outputBytes[x, y].G;
				outputDto.Data[index + 2] = outputBytes[x, y].B;

				index += 3;
			}
		}

		string outputString = System.Text.Json.JsonSerializer.Serialize(outputDto);

		return outputString;
	}
}