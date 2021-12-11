using System.Diagnostics;

[DebuggerDisplay("{X},{Y}")]
internal class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Point(int x, int y)
    {
        X = x; Y = y;
    }

    public List<Point> Neighbours
    {
        get
        {
            var result = new List<Point>();
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (Y + y < 0 || Y + y >= 10) continue;
                    if (X + x < 0 || X + x >= 10) continue;
                    if (y == 0 && x == 0) continue;
                    result.Add(new Point(X + x, Y + y));
                }
            }
            return result;
        }
    }

    protected bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

