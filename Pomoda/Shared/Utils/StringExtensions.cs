namespace Pomoda.Shared.Utils;

public static class StringExtensions
{
    public static string Peek(this string? text, int characters) => new string(text?.Take(characters).ToArray());
}
