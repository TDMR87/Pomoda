namespace Pomoda.Backend.Services;

public interface IMovieService
{
    Task<MovieSearchResponse<MovieDetails>> SearchByKeywordAsync(string keyword, int page);
    Task<MovieDetails?> GetById(string movieId);
}