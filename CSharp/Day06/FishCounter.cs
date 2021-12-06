internal class FishCounter
{
    private static Dictionary<int, long> cache = new Dictionary<int, long>();

    internal static long CountSuccessors(int age, int days)
    {
        if (days <= age)
        {
            return 1;
        }

        var d = days - age - 1;
        long result = 1;

        while (d >= 0)
        {
            result += CountNew(d);
            d -= 7;
        }
        return result;
    }

    private static long CountNew(int days)
    {
        if (cache.ContainsKey(days))
        {
            return cache[days];
        }

        long result = 1;
        var d = days - 9;
        while (d >= 0)
        {
            result += CountNew(d);
            d -= 7;
        }
        cache[days] = result;
        return result;
    }
}

