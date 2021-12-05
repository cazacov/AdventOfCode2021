using System.Diagnostics;
using System.Text.RegularExpressions;

[DebuggerDisplay("{X1},{Y1}->{X2},{Y2}")]
internal class Line
{
    public int X1;
    public int Y1;

    public int X2;
    public int Y2;

    public Line(string str)
    {
        var pattern = @"(\d+),(\d+) -> (\d+),(\d+)";
        var match = Regex.Match(str, pattern);
        if (!match.Success) { 
            throw new ArgumentException("Invalid input");
        }
        X1 = Int32.Parse(match.Groups[1].Value);
        Y1 = Int32.Parse(match.Groups[2].Value);
        X2 = Int32.Parse(match.Groups[3].Value);
        Y2 = Int32.Parse(match.Groups[4].Value);
    }

    internal void Apply(ref int[,] map)
    {
        var dirx = 0;
        if (X1 < X2) { dirx = 1; }
        if (X1 > X2) { dirx = -1; }

        var diry = 0;
        if (Y1 < Y2) { diry = 1; }
        if (Y1 > Y2) { diry = -1; }

        var x = X1 - dirx;
        var y = Y1 - diry;
        do
        {
            x += dirx;
            y += diry;
            map[x, y] = map[x, y] + 1;
        } while (x != X2 || y != Y2);
    }

    /// <summary>
    /// The line is horizontal or vertical
    /// </summary>
    public bool IsHorV
    {
        get
        {
            return X1 == X2 || Y1 == Y2;
        }
    }
}
