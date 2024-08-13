namespace Fukicycle.Tool.LINQExtensions;

public static class Join
{
    public static string JoinToString<T>(this IEnumerable<T> src, string separator = ",")
    {
        return string.Join(separator, src);
    }

    public static string JoinToString<TSource, TResult>(this IEnumerable<TSource> src, Func<TSource, TResult> predicate, string separator = ",")
    {
        return string.Join(separator, src.Select(predicate));
    }
}