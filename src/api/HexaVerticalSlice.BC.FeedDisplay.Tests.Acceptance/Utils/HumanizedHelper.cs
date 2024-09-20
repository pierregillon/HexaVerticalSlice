using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;

public static class HumanizedHelper
{
    public static T ParseEnum<T>(string humanizedString) where T : Enum => (T)ParseEnum(typeof(T), humanizedString);

    public static object ParseEnum(Type enumType, string humanizedString)
    {
        var normalized = FromHumanizedToNormalized(humanizedString);

        var isEnumFlag = enumType.GetCustomAttribute(typeof(FlagsAttribute)) != null;

        if (string.IsNullOrEmpty(normalized) && isEnumFlag)
        {
            return Activator.CreateInstance(enumType)!;
        }

        return Enum.Parse(enumType, normalized, true);
    }

    public static bool TryParseEnum<T>(string humanizedString, out T result) where T : Enum
    {
        if (TryParseEnum(typeof(T), humanizedString, out var result1))
        {
            result = (T)result1!;
            return true;
        }

        result = default!;
        return false;
    }

    public static bool TryParseEnum(Type enumType, string humanizedString, out object? result)
    {
        var normalized = FromHumanizedToNormalized(humanizedString);
        var isEnumFlag = enumType.GetCustomAttribute(typeof(FlagsAttribute)) != null;

        if (!string.IsNullOrEmpty(normalized) || !isEnumFlag)
        {
            return Enum.TryParse(enumType, normalized, true, out result);
        }
        
        result = Activator.CreateInstance(enumType) ?? throw new InvalidOperationException($"Unable to instanciate {enumType}");
        return true;
    }

    public static bool EqualsHumanized(this string input1, string input2) =>
        FromHumanizedToNormalized(input1) == FromHumanizedToNormalized(input2);

    public static string FromHumanizedToNormalized(string humanizedString) =>
        string.IsNullOrWhiteSpace(humanizedString)
            ? string.Empty
            : Regex.Replace(humanizedString.RemoveDiacritics()
                .ToLowerInvariant(), "[^a-z0-9,]+", "");

    public static IReadOnlyCollection<T> ParseEnums<T>(string humanizedString) where T : Enum =>
        humanizedString.Split(",")
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Select(ParseEnum<T>)
            .ToArray();

    private static string RemoveDiacritics(this string text)
    {
        var str = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();
        foreach (var ch in str)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(ch);
            }
        }

        return stringBuilder.ToString()
            .Normalize(NormalizationForm.FormC);
    }
}
