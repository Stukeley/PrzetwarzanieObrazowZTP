using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzetwarzanieObrazow.Web.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// API Gateway
builder.Services.AddSingleton<ApiGatewayController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

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

app.MapRazorPages();

app.Run();