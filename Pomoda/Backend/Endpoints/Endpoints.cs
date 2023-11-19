using static Pomoda.Frontend.Components.MovieDetailsList;

namespace Pomoda.Backend.Endpoints;

public static class Endpoints
{
    public const string SearchMoviesByKeyword = "search-movies-by-keyword";
    public const string OpenMovieDetailsDialog = "open-movie-details-dialog";
    public const string CloseMovieDetailsDialog = "close-movie-details-dialog";

    public static void AddHtmxEndpoints(this WebApplication app)
    {
        app.MapPost(SearchMoviesByKeyword, async (HttpContext context, [FromServices] IMovieService movieService) =>
        {
            var form = await context.Request.ReadFormAsync();
            var keyword = form.ContainsKey("keyword") ? form["keyword"].ToString() : string.Empty;
            var page = form.ContainsKey("page") ? int.Parse(form["page"]!) : 1;

            var movies = await movieService.SearchByKeywordAsync(keyword, page);

            var parameters = new MovieDetailsListParameters 
            { 
                Movies = movies, 
                Keyword = keyword 
            };

            return Razor.Component<MovieDetailsList>(parameters);
        });

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
