namespace Pomoda.Shared.Models;

/*
 * The classes in this file are modeling data returned 
 * from the 3rd party movie database.
 */

public class MovieSearchResponse<T>
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<T> Results { get; set; } = new List<T>();

    [JsonPropertyName("total_pages")]

    public int TotalPages { get; set; }

    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}
