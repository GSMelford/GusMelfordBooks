namespace GusMelfordBooks.Extensions;

public static class TypeCast
{
    public static DateTime? ToDateTime(this string value)
    {
        return DateTime.TryParse(value, out DateTime result) ? result : null;
    }
}