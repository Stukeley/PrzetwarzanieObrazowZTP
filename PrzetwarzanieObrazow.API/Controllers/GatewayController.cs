namespace PrzetwarzanieObrazow.API.Controllers;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Properties;

[Route("api/gateway")]
[ApiController]
public class GatewayController : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> Post([FromBody]ImageDataObject obj)
	{
		string algorithmName = obj.Algorithm;
		
		// Invoke highpass algorithm through the AlgorithmsController endpoints.
		// Send an API request to /api/algorithms/highpass.
		using (var client = new HttpClient())
		{
			var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
			
			var response = await client.PostAsync($"{Settings.ApplicationUrl}/api/algorithms/{algorithmName}", content);
			
			string result = await response.Content.ReadAsStringAsync();
			
			return Ok(result);
		}
	}
}