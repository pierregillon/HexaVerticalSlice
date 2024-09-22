namespace HexaVerticalSlice.Api.BuildingBlocks;

public static class StringExtensions
{
    public static string TrimEnd(this string value, string endValue) =>
        !value.EndsWith(endValue)
            ? value
            : value[..^endValue.Length];
}