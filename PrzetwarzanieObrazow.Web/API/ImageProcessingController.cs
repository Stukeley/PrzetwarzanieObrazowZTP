namespace PrzetwarzanieObrazow.Web.API;

using Code.Algorithms;
using Code.Builders;
using Microsoft.AspNetCore.Mvc;
using Requests;

public class ImageProcessingController : ControllerBase
{
	[HttpPost(Name = "HighPassFilter")]
	public IActionResult HighPassFilter([FromForm]ImageProcessingRequest request)
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