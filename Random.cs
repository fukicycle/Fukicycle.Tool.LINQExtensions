namespace Fukicycle.Tool.LINQExtensions;

public static class Random
{
    public static IEnumerable<T> TakeRandomValues<T>(this IEnumerable<T> src, int count)
    {
        if (src.Count() <= count)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }
        return src.OrderBy(a => Guid.NewGuid()).Take(count);
    }

    public static T TakeRandomValue<T>(this IEnumerable<T> src)
    {
        return src.TakeRandomValues(1).Single();
    }

    public static IEnumerable<IGrouping<int, T>> GroupByCount<T>(this IEnumerable<T> src, int countPerGroup)
    {
        if (countPerGroup <= 0)
        {
            throw new ArgumentException($"Can not use less equal 0.");
        }
        if (src.Count() / countPerGroup <= 1)
        {
            throw new ArgumentException($"Can not grouping by specified count. List size: {src.Count()}, Specified size: {countPerGroup}");
        }
        int idx = 0;
        return src.GroupBy(a => GetGroupIndex(idx++, countPerGroup));
    }

    private static int GetGroupIndex(int count, int countPerGroup)
    {
        return count / countPerGroup;
    }
}
