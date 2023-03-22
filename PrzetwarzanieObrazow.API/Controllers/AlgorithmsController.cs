namespace PrzetwarzanieObrazow.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AlgorithmsController: ControllerBase
{
	[HttpGet]
	[Route("highpass")]
	public IActionResult Test()
	{
		return Ok("Test");
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		return Ok("GetALl");
	}
}