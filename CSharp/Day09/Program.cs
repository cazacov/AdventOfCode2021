using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 9");
var map = ReadHeightMap("input.txt");

var lowPoints = Puzzle1(map);
Puzzle2(map, lowPoints);

List<Point> Puzzle1(Dictionary<Point, int> map)
{
    var result = new List<Point>();
    int risk = 0;
    for (int i = 0;  i < 100; i++)
    {
        for (int j = 0; j < 100; j++)
        {
            var point = new Point(j, i);
            var depth = map[point];
            if (point.Neighbours.All(p => map[p] > depth))
            {
                risk += 1 + map[point];
                result.Add(point);
            }
        }
    }
    Console.WriteLine(risk);
    return result;
}

void Puzzle2(Dictionary<Point, int> map, List<Point> lowPoints)
{
    var basinSizes = new List<int>();

    foreach (var point in lowPoints)
    {
        int basinSize = 0;
        var current = point;
        var todo = new HashSet<Point>();
        var inspected = new HashSet<Point>();

        do
        {
            inspected.Add(current);
            basinSize++;
            foreach (var next in current.Neighbours)
            {
                if (inspected.Contains(next))
                {
                    continue;
                }  
                if  (map[next] == 9)
                {
                    continue;
                }
                todo.Add(next);
            }
            todo.Remove(current);
            if (todo.Count > 0)
            {
                current = todo.First();
            }
            else
            {
                current = null;
            }
        } while (current != null);
        basinSizes.Add(basinSize);
    }
    Console.WriteLine(basinSizes
                        .OrderByDescending(x => x)
                        .Take(3)
                        .Aggregate(1, (acc, item) => acc * item));
}

Dictionary<Point,int> ReadHeightMap(string fileName)
{
    var result = new Dictionary<Point, int>();

    var lines = System.IO.File.ReadAllLines(fileName);
    for (int i = 0; i < 100; i++)
    {
        var str = lines[i];
        for (int j = 0; j < 100; j++)
        {
            result[new Point(j, i)] = Int32.Parse(str[j].ToString());
        }
    }
    return result;
}
