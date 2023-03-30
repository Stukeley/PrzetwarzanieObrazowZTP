namespace PrzetwarzanieObrazow.API.Controllers;

using System.Net.Http;
using System.Net.Http.Json;
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
		var algorithmName = obj.Algorithm;
		
		// Invoke highpass algorithm through the AlgorithmsController endpoints.
		// Send an API request to /api/algorithms/highpass.
		using (var client = new HttpClient())
		{
			// TODO: requesty źle się wysyłają i nie działają poprawnie, a Postman tak
			var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(obj));
			
			var response = await client.PostAsJsonAsync($"{Settings.ApplicationUrl}/api/algorithms/{algorithmName}", content);
			
			string result = await response.Content.ReadAsStringAsync();
			
			return Ok(result);
		}
	}
}