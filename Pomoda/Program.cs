var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "Frontend"
});

builder.Services.AddRazorComponents();
builder.Services.AddHttpClient<MovieService>();

var app = builder.Build();
app.AddMovieEndpoints();
app.UseNotFoundMiddleware();

var fileOptions = new DefaultFilesOptions();
fileOptions.DefaultFileNames.Clear();
fileOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(fileOptions);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Frontend"))
});

app.Run();