using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pomoda.Shared.Utils;

public static class StringExtensions
{
    /// <summary>
    /// Returns only the beginning of a long string.
    /// </summary>
    /// <param name="text">
    /// The source text.
    /// </param>
    /// <param name="characters">
    /// The character count to return.
    /// </param>
    /// <returns></returns>
    public static string Peek(this string? text, int characters) => new string(text?.Take(characters).ToArray());
}
