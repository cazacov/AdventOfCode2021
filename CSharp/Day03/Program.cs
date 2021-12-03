using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 3");
var input = Helpers.ReadStrings("input.txt");

const int N = 12;

Puzzle1(input);
Puzzle2(input);

void Puzzle1(List<string> input)
{
    var bits = CountBits(input);

    int num1 = 0;
    int pow = 1;
    for (int i = N-1; i >= 0; i--)
    {
        if (bits[i] > input.Count / 2)
        {
            num1 += pow;
        } 
        pow *= 2;
    }

    var num2 = ~num1 & 0x0FFF;
    Console.WriteLine(num1 * num2);
}

void Puzzle2(List<string> input)
{
    var oxy = new List<string>(input);
    while(oxy.Count > 1)
    {

        for (int i = 0; i < N; i++)
        {
            if (oxy.Count == 1)
            {
                break;
            }
            var f1 = CountBits(oxy);
            if (f1[i] >= oxy.Count / 2.0)
            {
                oxy = oxy.Where(x => x[i] == '1').ToList();
            }
            else
            {
                oxy = oxy.Where(x => x[i] == '0').ToList();
            }
        }
    }
    var oxn = Convert.ToInt32(oxy.First(),2);


    var co2 = new List<string>(input);
    while (co2.Count > 1)
    {

        for (int i = 0; i < N; i++)
        {
            if (co2.Count == 1)
            {
                break;
            }
            var f1 = CountBits(co2);
            if (f1[i] < co2.Count / 2.0)
            {
                co2 = co2.Where(x => x[i] == '1').ToList();
            }
            else
            {
                co2 = co2.Where(x => x[i] == '0').ToList();
            }
        }
    }
    var co2n = Convert.ToInt32(co2.First(), 2);
    Console.WriteLine(co2n * oxn);
}

int[] CountBits(IEnumerable<string> input)
{
    var bits = new int[N];
    
    foreach (var num in input)
    {
        for (int i = 0; i < N; i++)
        {
            if (num[i] == '1')
            {
                bits[i]++;
            }
        }
    }
    return bits;
}


