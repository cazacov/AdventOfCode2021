using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 8");

var displays = Helpers.ReadStrings("input.txt").ConvertAll(x => new Display(x));

Puzzle1(displays);
Puzzle2(displays);

void Puzzle1(List<Display> displays)
{
    var simpleLengths = new int[] { 2, 3, 4, 7 };
    Console.WriteLine(displays.SelectMany(x => x.Output, (x,y) => y).Count(x => simpleLengths.Contains(x.Length)));
}

void Puzzle2(List<Display> displays)
{
    Console.WriteLine(displays.Sum(x => x.Result));
}