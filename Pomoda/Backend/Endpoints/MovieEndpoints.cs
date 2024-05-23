namespace Pomoda.Backend.Endpoints;

public static class MovieEndpoints
{
    public const string SearchMoviesByKeyword = "search-movies-by-keyword";
    public const string OpenMovieDetailsDialog = "open-movie-details-dialog";
    public const string CloseMovieDetailsDialog = "close-movie-details-dialog";

    public static void AddMovieEndpoints(this WebApplication app)
    {
        app.MapPost(SearchMoviesByKeyword, async (MovieService movieService, [FromForm] string keyword, [FromForm] int page = 1) =>
        {
            var movies = await movieService.GetMoviesByKeywordAsync(keyword, page);

            var parameters = new MovieDetailsListParameters 
            { 
                Movies = movies, 
                Keyword = keyword 
            };

            return Razor.Component<MovieDetailsList>(parameters);

        }).DisableAntiforgery();

        app.MapGet(OpenMovieDetailsDialog, async (MovieService movieService, [FromQuery] string movieId) =>
        {
            MovieDetails? movie = await movieService.GetMovieById(movieId);
            return Razor.Component<MovieDetailsDialog>(movie);
        });

        app.MapGet(CloseMovieDetailsDialog, () =>
        {
            return Razor.Component<Empty>();
        });
    }
}
