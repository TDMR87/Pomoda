namespace Pomoda.Shared.Models;

public class MovieDetailsResponse<T>
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<T> Results { get; set; } = [];
}