using PrzetwarzanieObrazow.API.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// API Gateway.
builder.Services.AddSingleton<ApiGatewayController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
	var apiGatewayController = context.RequestServices.GetService<ApiGatewayController>();

	var response = await apiGatewayController.Get(context.Request.RouteValues["microserviceName"].ToString(),
		context.Request.Path.Value.Substring(context.Request.Path.Value.IndexOf('/') + 1) + context.Request.QueryString);

	var content = await response.Content.ReadAsStreamAsync();
	// ?
	// await context.Response.Body.WriteAsync(content.ToArray());

	await next(context);
});

app.MapControllers();

app.Run();