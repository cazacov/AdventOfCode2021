using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 10");

var lines = System.IO.File.ReadAllLines("input.txt");

Puzzle1(lines);
Puzzle2(lines);

void Puzzle1(string[] lines)
{
    long result = 0;
    foreach (var line in lines)
    {
        Char? ch = FirstIllegalCharacter(line);
        if (ch != null)
        {
            result += Score(ch.Value);
        }
    }
    Console.WriteLine(result);
}

void Puzzle2(string[] lines)
{
    var closingScores = new List<long>();
    foreach (var line in lines)
    {
        var score = LineClosingScore(line);
        if (score > 0)
        {
            closingScores.Add(score);
        }
    }
    closingScores.Sort();
    Console.WriteLine(closingScores[closingScores.Count/2]);
}

long LineClosingScore(string line)
{
    var stack = new Stack<Char>();

    var pushChars = new[] { '(', '[', '<', '{' };
    var pullChars = new[] { ')', ']', '>', '}' };

    foreach (var c in line)
    {
        if (pushChars.Contains(c)) stack.Push(c);

        if (pullChars.Contains(c))
        {
            if (stack.Count == 0)
            {
                return 0;
            }
            var stackVal = stack.Pop();
            if (stackVal != Pair(c))
            {
                return 0;
            }
        }
    }
    var result = 0L;
    while (stack.Count > 0)
    {
        result = result*5 + ClosingScore(Pair(stack.Pop()));
    }
    return result;
}

char? FirstIllegalCharacter(string line)
{
    var stack = new Stack<Char>();

    var pushChars = new[] { '(', '[', '<', '{' };
    var pullChars = new[] { ')', ']', '>', '}' };

    foreach (var c in line)
    {
        if (pushChars.Contains(c)) stack.Push(c);

        if (pullChars.Contains(c))
        {
            if (stack.Count == 0)
            {
                return c;
            }
            var stackVal = stack.Pop();
            if(stackVal != Pair(c))
            {
                return c;
            }
        }
    }
    return null;
}

char Pair(char c)
{
    switch (c)
    {
        case '(':
            return ')';
        case '[':
            return ']';
        case '<':
            return '>';
        case '{':
            return '}';
        case ')':
            return '(';
        case ']':
            return '[';
        case '>':
            return '<';
        case '}':
            return '{';
    }
    return 'x';
}

long Score(char value)
{
    switch(value)
    {
        case ')':
            return 3;
        case ']':
            return 57;
            case '}':
            return 1197;
        case '>':
            return 25137;
    }
    return 0;
}

int ClosingScore(char value)
{
    switch (value)
    {
        case ')':
            return 1;
        case ']':
            return 2;
        case '}':
            return 3;
        case '>':
            return 4;
    }
    return 0;
}