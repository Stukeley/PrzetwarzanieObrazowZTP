namespace PrzetwarzanieObrazow.API.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/algorithms")]
[ApiController]
public class AlgorithmsController: ControllerBase
{
	[HttpGet]
	[Route("highpass")]
	public async Task<IActionResult> Highpass()
	{
		return Ok("Highpass");
	}
	
	[HttpGet]
	[Route("grayscale")]
	public async Task<IActionResult> Grayscale()
	{
		return Ok("Grayscale");
	}
}