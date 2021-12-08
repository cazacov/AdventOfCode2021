using AocHelpers;

internal class Display
{
    public Display(string input)
    {

        var patterns = input.Substring(0, 59).Trim();
        this.Patterns = patterns.Split(" ").Select(x => Helpers.SortCharacters(x)).ToArray();
        var outputs = input.Substring(60).Trim();
        this.Output = outputs.Split(" ").Select(x => Helpers.SortCharacters(x)).ToArray();
        int result = CalculateResult();
        this.Result = result;
    }

    private int CalculateResult()
    {
        var one = this.Patterns.First(p => p.Length == 2);
        var four = this.Patterns.First(p => p.Length == 4);
        var seven = this.Patterns.First(p => p.Length == 3);
        var eight = this.Patterns.First(p => p.Length == 7);

        var A = Helpers.SubtractStrings(seven, one);
        var BD = Helpers.SubtractStrings(four, one);
        var ABDEG = Helpers.SubtractStrings(eight, one);
        var AEG = Helpers.SubtractStrings(ABDEG, BD);
        var EG = Helpers.SubtractStrings(AEG, A);

        var two = this.Patterns.Where(s => s.Length == 5).First(x => Helpers.SubtractStrings(x, EG).Length == 3);
        var F = Helpers.SubtractStrings(one, two);
        var C = Helpers.SubtractStrings(one, F);
        var six = Helpers.SubtractStrings(eight, C);
        var three = this.Patterns.Where(s => s.Length == 5).First(x => x != two && x.Contains(C));
        var five = this.Patterns.Where(s => s.Length == 5).First(x => x != two && x != three);
        var nine = Helpers.SortCharacters(five + C);
        var zero = this.Patterns.Where(s => s.Length == 6).First(x => x != six && x != nine);

        var result = 0;
        foreach (var o in this.Output)
        {
            result *= 10;
            if (o == one)
            {
                result += 1;
            }
            else if (o == two)
            {
                result += 2;
            }
            else if (o == three)
            {
                result += 3;
            }
            else if (o == four)
            {
                result += 4;
            }
            else if (o == five)
            {
                result += 5;
            }
            else if (o == six)
            {
                result += 6;
            }
            else if (o == seven)
            {
                result += 7;
            }
            else if (o == eight)
            {
                result += 8;
            }
            else if (o == nine)
            {
                result += 9;
            }
        }

        return result;
    }

    public string[] Patterns { get; private set; }
    public string[] Output { get; private set; }
    public int Result { get; }
}

