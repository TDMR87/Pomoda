namespace Pomoda.Models;

/*
 * The classes in this file are just modeling data returned 
 * from the 3rd party movie database and make serialization easier.
 */

public class MovieDetailsResponse<T>
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<T> Results { get; set; } = new List<T>();
}