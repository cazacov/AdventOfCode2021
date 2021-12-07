using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 7");

var positions = AocHelpers.Helpers.ReadCsvInts("input.txt");

Puzzle1(positions);
Puzzle2(positions);

void Puzzle1(List<int> positions)
{
    Console.WriteLine(FindOptimal(positions, Cost));
}

void Puzzle2(List<int> positions)
{
    Console.WriteLine(FindOptimal(positions, Cost2));
}

int FindOptimal(List<int> positions, Func<List<int>, int, int> cost)
{
    var from = positions.Min();
    var to = positions.Max();

    var minval = Int32.MaxValue;
    for (int i = from; i <= to; i++)
    {
        var c = cost(positions, i);
        if (c < minval)
        {
            minval = c;
        }
    }
    return minval;
}

int Cost(List<int> positions, int val)
{
    return positions.Sum(x => Math.Abs(x - val));
}

int Cost2(List<int> positions, int val)
{
    return positions.Sum(x => {
            var n = Math.Abs(x - val);
            return n * (n+1) / 2;
        }
    );
}