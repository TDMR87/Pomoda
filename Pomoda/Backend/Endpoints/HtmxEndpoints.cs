using static Pomoda.Frontend.Components.MovieDetailsList;

namespace Pomoda.Backend.Endpoints;

public static class HtmxEndpoints
{
    public const string SearchMoviesByKeyword = "search-movies-by-keyword";
    public const string OpenMovieDetailsDialog = "open-movie-details-dialog";
    public const string CloseMovieDetailsDialog = "close-movie-details-dialog";

    public static void AddHtmxEndpoints(this WebApplication app)
    {
        app.MapPost(SearchMoviesByKeyword, async (
            IMovieService movieService, 
            [FromForm] string keyword, 
            [FromForm] int page = 1) =>
        {
            var movies = await movieService.SearchByKeywordAsync(keyword, page);

            var parameters = new MovieDetailsListParameters 
            { 
                Movies = movies, 
                Keyword = keyword 
            };

            return Razor.Component<MovieDetailsList>(parameters);

        }).DisableAntiforgery();

        app.MapGet(OpenMovieDetailsDialog, async ([FromQuery] string movieId, [FromServices] IMovieService movieService) =>
        {
            MovieDetails? movie = await movieService.GetById(movieId);
            return Razor.Component<MovieDetailsDialog>(movie);
        });

        app.MapGet(CloseMovieDetailsDialog, () =>
        {
            return Razor.Component<Empty>();
        });
    }
}
