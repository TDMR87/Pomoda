namespace Pomoda.Backend.Services;

/// <summary>
/// This service retrieves movie data from an external movie database API.
/// </summary>
public class MovieService : IMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MovieService(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Retrieves details of movies that match the specified search keyword.
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="includeAdult"></param>
    /// <returns></returns>
    public async Task<MovieSearchResponse<MovieDetails>> SearchByKeywordAsync(string keyword, int page)
    {
        var httpClient = _httpClientFactory.CreateClient("MovieDatabase");

        var response = await httpClient.GetAsync
        (
            $"search/multi?query={keyword}" +
            $"&include_adult=false" +
            $"&page={page}"
        );

        if (response.IsSuccessStatusCode)
        {
            var movies = await response.Content.ReadFromJsonAsync<MovieSearchResponse<MovieDetails>>()
                ?? new MovieSearchResponse<MovieDetails>();

            movies.Results = movies.Results.Where(
                movie => 
                movie.Title is not null &&
                movie.PosterPath is not null)
                .OrderByDescending(movie => movie.ReleaseDate)
                .ToList();

            return movies;
        }
        else
        {
            return new MovieSearchResponse<MovieDetails>();
        }
    }

    /// <summary>
    /// Returns details of a single movie with the specified id.
    /// </summary>
    /// <param name="movieId"></param>
    /// <returns></returns>
    public async Task<MovieDetails?> GetById(string movieId)
    {
        var httpClient = _httpClientFactory.CreateClient("MovieDatabase");

        var response = await httpClient.GetAsync($"movie/{movieId}");

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
