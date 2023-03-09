using Microsoft.Extensions.Primitives;

namespace Application.Common;

public static class Utilities
{
    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

    public static bool IsNullOrEmpty(this StringValues value) => StringValues.IsNullOrEmpty(value);
}