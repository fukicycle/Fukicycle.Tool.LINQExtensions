namespace Fukicycle.Tool.LINQExtensions;

public static class ShuffleExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> src)
    {
        return src.OrderBy(a => Guid.NewGuid());
    }
}
