﻿namespace PrzetwarzanieObrazow.API.Controllers;

using System.Net.Http;
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
		
		// Invoke the right algorithm through the AlgorithmsController endpoints.
		// Send an API request to /api/algorithms/[algorithm name].
		using (var client = new HttpClient())
		{
			var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
			
			var response = await client.PostAsync($"{Settings.Instance.ApplicationUrl}/api/algorithms/{algorithmName}", content);
			
			string result = await response.Content.ReadAsStringAsync();
			
			return Ok(result);
		}
	}
}