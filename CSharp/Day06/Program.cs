Console.WriteLine("Advent of Code 2021, day 6");

var fishes = System.IO.File.ReadAllText("input.txt").Split(",").ToList().ConvertAll(Int32.Parse).ConvertAll(x => new Fish(x, 7));
Puzzle1(fishes);

fishes = System.IO.File.ReadAllText("input.txt").Split(",").ToList().ConvertAll(Int32.Parse).ConvertAll(x => new Fish(x, 7));
Puzzle2(fishes);

void Puzzle1(List<Fish> fishes)
{
    for (int i = 0; i < 80; i++)
    {
        List<Fish> nextGen = new List<Fish>();
        foreach (var fish in fishes)
        {
            var next = fish.Next();
            if (next != null)
            {
                nextGen.Add(next);
            }
        }
        fishes.AddRange(nextGen);
    }
    Console.WriteLine(fishes.Count);
}

void Puzzle2(List<Fish> fishes)
{
    long result = 0;

    for (int i = 0; i < 7; i++)
    {
        var cnt = fishes.Count(f => f.Days == i);
        if (cnt > 0)
        {
            var n = FishCounter.CountSuccessors(i, 256);
            result += n*cnt;
        }
    }
    Console.WriteLine(result);
}