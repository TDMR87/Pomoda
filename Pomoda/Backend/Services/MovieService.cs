namespace Pomoda.Backend.Services;

public class MovieService
{
    private readonly HttpClient _httpClient;

    public MovieService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        httpClient.BaseAddress = new Uri(configuration["MovieDatabase:ApiBaseAddress"]!);

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
        (
            "Bearer", configuration["MovieDatabase:ApiAccessToken"]
        );
    }

    public async Task<MovieSearchResponse<MovieDetails>> GetMoviesByKeywordAsync(string keyword, int page)
    {
        var response = await _httpClient.GetAsync
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

    public async Task<MovieDetails?> GetMovieById(string id)
    {
        var response = await _httpClient.GetAsync($"movie/{id}");

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<MovieDetails>()
            : null;
    }
}
