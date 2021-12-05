using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 5");
var lines = Helpers.ReadStrings("input.txt").ConvertAll(x => new Line(x));


Puzzle1(lines);
Puzzle2(lines);

void Puzzle1(List<Line> lines)
{
    var map = new int[1000, 1000];
    foreach (var line in lines)
    {
        if (!line.IsHorV)
        {
            continue;
        }
        line.Apply(ref map);
    }
    Console.WriteLine(CountDangerousPlaces(map));
}

void Puzzle2(List<Line> lines)
{
    var map = new int[1000, 1000];
    foreach (var line in lines)
    {
        line.Apply(ref map);
    }
    Console.WriteLine(CountDangerousPlaces(map));
}

int CountDangerousPlaces(int[,] map)
{
    var count = 0;
    for (int i = 0; i < 1000; i++)
    {
        for (int j = 0; j < 1000; j++)
        {
            if (map[i, j] > 1)
            {
                count++;
            }
        }
    }
    return count;
}