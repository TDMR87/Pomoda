using Pomoda.Models;

namespace Pomoda.Services;

/// <summary>
/// This service retrieves movie data from an external movie database API.
/// </summary>
public class MovieService : IMovieService
{
    private readonly ILogger<MovieService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public MovieService(ILogger<MovieService> logger, IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Retrieves movies by search keyword.
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="includeAdult"></param>
    /// <returns></returns>
    public async Task<IEnumerable<MovieDetails>> GetByKeywordAsync(string keyword)
    {
        var httpClient = _httpClientFactory.CreateClient("MovieDatabase");

        var response = await httpClient.GetAsync
        (
            $"search/multi?query={keyword}" +
            $"&include_adult=false" +
            $"&language=en-US&page=1"
        );

        if (response.IsSuccessStatusCode)
        {
            var movies = await response.Content.ReadFromJsonAsync<MovieSearchResponse<MovieDetails>>();
            return movies?.Results.Where(m => m.Title is not null && m.PosterPath is not null) ?? Enumerable.Empty<MovieDetails>();
        }
        else
        {
            return Enumerable.Empty<MovieDetails>();
        }
    }

    public async Task<MovieDetails?> GetById(string movieId)
    {
        var httpClient = _httpClientFactory.CreateClient("MovieDatabase");

        var response = await httpClient.GetAsync($"movie/{movieId}?language=en-US");

        if (response.IsSuccessStatusCode)
        {
            var movie = await response.Content.ReadFromJsonAsync<MovieDetails>();
            return movie;
        }
        else
        {
            return null;
        }
    }
}
