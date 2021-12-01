Console.WriteLine("Advent Of Code Day 1");

var depth = ReadInput("input.txt");

Puzzle1(depth);
Puzzle2(depth);

void Puzzle1(List<int> depth)
{
    int cnt = 0;

    for (int i = 0; i < depth.Count-1; i++)
    {
        if (depth[i] < depth[i+1])
        {
            cnt++;
        }
    }
    Console.WriteLine(cnt); 
}

void Puzzle2(List<int> depth)
{
    int cnt = 0;

    for (int i = 0; i < depth.Count - 3; i++)
    {
        if (depth[i] < depth[i + 3])
        {
            cnt++;
        }
    }
    Console.WriteLine(cnt);
}

List<int> ReadInput(string fileName)
{
    return System.IO.File.ReadAllLines(fileName).ToList().ConvertAll(x => Int32.Parse(x));
}