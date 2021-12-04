using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 4");
var input = Helpers.ReadStrings("input.txt");

var numbers = input[0].Split(",").ToList().ConvertAll(x => Int32.Parse(x)).ToList();
var boards = ParseBoards(input.Skip(2));


Puzzle1(boards, numbers);

foreach(var board in boards)
{
    board.Reset();
}

Puzzle2(boards, numbers);





void Puzzle1(List<Board> boards, List<int> numbers)
{
    foreach (var n in numbers)
    {
        foreach (var board in boards)
        {
            board.Mark(n);
            if (board.HasWon())
            {
                Console.WriteLine(board.Score * n);
                return;
            }
        }
    }
}

void Puzzle2(List<Board> boards, List<int> numbers)
{
    var set = new HashSet<Board>(boards);
    foreach (var n in numbers)
    {
        foreach (var board in boards)
        {
            board.Mark(n);
            if (board.HasWon())
            {
                set.Remove(board);
                if (set.Count == 0)
                {
                    Console.WriteLine(board.Score * n); 
                    return;
                }
            }
        }
    }
}

List<Board> ParseBoards(IEnumerable<string> enumerable)
{
    var result = new List<Board>();
    var numbers = new List<int>();    
    foreach (var str in enumerable) { 
        if (String.IsNullOrWhiteSpace(str))
        {
            result.Add(new Board(numbers));
            numbers.Clear();
        }
        numbers.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(Int32.Parse));
    }
    if (numbers.Count > 0)
    {
        result.Add(new Board(numbers));
    }
    return result;
}
