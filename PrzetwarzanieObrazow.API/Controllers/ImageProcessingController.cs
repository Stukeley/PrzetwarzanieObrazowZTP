namespace PrzetwarzanieObrazow.API.Controllers;

using Code.Algorithms;
using Code.Builders;
using Microsoft.AspNetCore.Mvc;

public class ImageProcessingController : ControllerBase
{
	[HttpPost(Name = "HighPassFilter")]
	public IActionResult HighPassFilter([FromForm]object request)
	{
		// TODO
		ImageAlgorithm highPassFilter = new ImageFilterBuilder().BuildHighPassFilterAlgorithm(null);
		var outputImage = highPassFilter.Process();
		
		return Ok(outputImage);
	}
	
	[HttpGet(Name = "Test")]
	public IActionResult Test()
	{
		return Ok("Test");
	}
}