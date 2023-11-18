using Pomoda.Models;

namespace Pomoda.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDetails>> GetByKeywordAsync(string keyword);
    Task<MovieDetails?> GetById(string movieId);
}