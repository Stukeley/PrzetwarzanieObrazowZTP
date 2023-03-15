namespace PrzetwarzanieObrazow.Web.API;

using Microsoft.AspNetCore.Mvc;

// https://medium.com/streamwriter/api-gateway-aspnet-core-a46ef259dc54
// todo: api gateway
[Route("api/[Controller]")]
[ApiController]
public class ImageProcessingController : ControllerBase
{
	// [Route("HighPassFilter")]
	// [HttpPost]
	// public IActionResult HighPassFilter([FromForm]ImageProcessingRequest request)
	// {
	// 	ImageAlgorithm highPassFilter = new HighPassFilter(request.InputImage, request.Width, request.Height);
	// 	var outputImage = highPassFilter.Process();
	// 	
	// 	return Ok(outputImage);
	// }
	//
	// [Route("Test")]
	// [HttpGet]
	// public IActionResult Test()
	// {
	// 	return Ok("Test");
	// }
}