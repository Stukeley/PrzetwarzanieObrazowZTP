namespace PrzetwarzanieObrazow.API.Controllers;

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Properties;

[Route("api/gateway")]
[ApiController]
public class GatewayController : ControllerBase
{
	[HttpGet]
	[Route("highpass")]
	public async Task<IActionResult> Highpass()
	{
		// Invoke highpass algorithm through the AlgorithmsController endpoints.
		// Send an API request to /api/algorithms/highpass.
		using (var client = new HttpClient())
		{
			var response = await client.GetAsync($"{Settings.ApplicationUrl}/api/algorithms/highpass");
			string content = await response.Content.ReadAsStringAsync();
			return Ok(content);
		}
	}
}