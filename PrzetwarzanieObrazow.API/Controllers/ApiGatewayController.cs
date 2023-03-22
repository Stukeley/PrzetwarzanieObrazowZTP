namespace PrzetwarzanieObrazow.API.Controllers;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class ApiGatewayController : ControllerBase
{
	private readonly HttpClient _httpClient;

	public ApiGatewayController()
	{
		_httpClient = new HttpClient();
	}
	
	[HttpGet]
	[Route("{microserviceName}/{*uri}")]
	public async Task<HttpResponseMessage> Get(string microserviceName, string uri)
	{
		// Forward the HTTP request to the appropriate microservice
		var request = new HttpRequestMessage(HttpMethod.Get, $"http://{microserviceName}/{uri}");
		return await _httpClient.SendAsync(request);
	}

	[HttpPost]
	[Route("{microserviceName}/{*uri}")]
	public async Task<HttpResponseMessage> Post(string microserviceName, string uri, [FromBody] object body)
	{
		// Forward the HTTP request to the appropriate microservice
		var request = new HttpRequestMessage(HttpMethod.Post, $"http://{microserviceName}/{uri}")
		{
			Content = JsonContent.Create(body, body.GetType())
		};
		return await _httpClient.SendAsync(request);
	}
}