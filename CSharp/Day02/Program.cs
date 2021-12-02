using AocHelpers;
using System.Text.RegularExpressions;

Console.WriteLine("Advent of Code 2021, day 2");
var commands = Helpers.ReadStrings("input.txt");


Puzzle1(commands);
Puzzle2(commands);

void Puzzle1(List<string> commands)
{
    var depth = 0;
    var pos = 0;

    var pattern = "(forward|up|down) (\\d+)";
    foreach (var command in commands)
    {
        var match = Regex.Match(command, pattern);

        if (!match.Success) { continue; }

        var cmd = match.Groups[1].Value;
        var val = Int32.Parse(match.Groups[2].Value);
        switch (cmd)
        {
            case "forward":
                pos += val;
                break;
            case "up":
                depth-=val;
                break;
            case "down":
                depth += val;
                break;
        }
    }
    Console.WriteLine(pos * depth);
}

void Puzzle2(List<string> commands)
{
    var pos = 0;
    var aim = 0;
    var depth = 0;

    var pattern = "(forward|up|down) (\\d+)";
    foreach (var command in commands)
    {
        var match = Regex.Match(command, pattern);

        if (!match.Success) { continue; }

        var cmd = match.Groups[1].Value;
        var val = Int32.Parse(match.Groups[2].Value);
        switch (cmd)
        {
            case "forward":
                pos += val;
                depth += aim * val;
                break;
            case "up":
                aim -= val;
                break;
            case "down":
                aim += val;
                break;
        }
    }
    Console.WriteLine(pos * depth);
}