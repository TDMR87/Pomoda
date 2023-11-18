global using Microsoft.AspNetCore.Mvc;
global using System.Text.Json.Serialization;
global using System.Net.Http.Headers;
global using Pomoda.Models;
global using Pomoda.Utils;
global using Pomoda.Services;
global using Pomoda.Endpoints;
global using Pomoda.Middleware;
global using Pomoda.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

// Add a custom CORS policy
builder.Services.AddCors
(
    cors => cors.AddPolicy(name: "default-policy", policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:5126", "https://localhost:7173"))
);

// Add a named HttpClient. We'll use this client to retrieve movie data from the 3rd party API
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

// Add our custom endpoints, which our front-end can call using HTMX
app.AddHtmxEndpoints();

// Configure a custom middleware to handle 404 responses.
// When page is not found, we'll serve the index page.
app.Use404Middleware();

// DefaultFiles() and UseStaticFiles() middlewares serve the wwwroot/index.html file
// (the front-end of this app)to the client when accessing the application base address.
app.UseDefaultFiles();
app.UseStaticFiles();

// Use our custom CORS policy
app.UseCors("default-policy");

// Confiogure HTTP requests to redirected to HTTPS
app.UseHttpsRedirection();

// Configurations done, run the app
app.Run();
