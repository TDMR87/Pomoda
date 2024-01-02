global using Microsoft.AspNetCore.Mvc;
global using System.Text.Json.Serialization;
global using System.Net.Http.Headers;
global using Pomoda.Shared.Models;
global using Pomoda.Shared.Utils;
global using Pomoda.Backend.Services;
global using Pomoda.Backend.Endpoints;
global using Pomoda.Backend.Middleware;
global using Pomoda.Frontend.Components;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "Frontend"
});

// Configure Razor Components to be used
builder.Services.AddRazorComponents();

// Add a named HttpClient for retrieving movie data from the 3rd party Movie API
builder.Services.AddHttpClient("MovieDatabase", (httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
    (
        "Bearer", builder.Configuration["MovieDatabase:ApiReadAccessToken"]
    );
});

// Add a service class for retrieving movie data.
builder.Services.AddSingleton<IMovieService, MovieService>();

var app = builder.Build();

// Add custom endpoints, which our frontend can call using HTMX
app.AddHtmxEndpoints();

// Configure a custom middleware to handle 404 responses.
// When page is not found, we'll serve the index page.
app.Use404Middleware();

// Configure default static files to be served to the client
var fileOptions = new DefaultFilesOptions();
fileOptions.DefaultFileNames.Clear();
fileOptions.DefaultFileNames.Add("index.html");
fileOptions.DefaultFileNames.Add("styles.css");
app.UseDefaultFiles(fileOptions);

// Configure the location of our static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Frontend"))
});

app.Run();
