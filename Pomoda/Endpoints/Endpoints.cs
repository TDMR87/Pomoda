namespace Pomoda.Endpoints;

public static class Endpoints
{
    public const string SearchMoviesByKeyword   = "search-movies-by-keyword";
    public const string OpenMovieDetailsDialog  = "open-movie-details-dialog";
    public const string CloseMovieDetailsDialog = "close-movie-details-dialog";

    public static void AddHtmxEndpoints(this WebApplication app)
    {
        app.MapPost(SearchMoviesByKeyword, async (HttpContext context, [FromServices] IMovieService movieService) =>
        {
            var form = await context.Request.ReadFormAsync();
            var keyword = form["keyword"];
            var movies = (await movieService.GetByKeywordAsync(keyword!)).ToList();

            return Razor.Component<MovieDetailsList>(model: movies);
        });

        app.MapGet(OpenMovieDetailsDialog, async ([FromQuery] string movieId, [FromServices] IMovieService movieService) =>
        {
            MovieDetails? movie = await movieService.GetById(movieId);
            return Razor.Component<MovieDetailsDialog>(model: movie);
        });

        app.MapGet(CloseMovieDetailsDialog, () =>
        {
            return Razor.Component<Empty>();
        });
    }
}
