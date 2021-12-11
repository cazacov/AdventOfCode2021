using AocHelpers;

Console.WriteLine("Advent of Code 2021, day 11");

int[,] energy = ReadInput("input.txt");

Puzzle1(energy);

energy = ReadInput("input.txt");
Puzzle2(energy);

void Puzzle1(int[,] energy)
{
    long flasCount = 0;


    for (int i = 0; i < 100; i++)
    {
        bool[,] flashes = new bool[10, 10];
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                energy[y, x] += 1;
            }
        }

        bool flashed = false;
        do
        {
            flashed = false;
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (energy[y, x] > 9)
                    {
                        flashed = true;
                        flasCount++;
                        flashes[y, x] = true;
                        foreach (var point in new Point(x, y).Neighbours)
                        {
                            if (!flashes[point.Y, point.X])
                            {
                                energy[point.Y, point.X] += 1;
                            }
                        }
                        energy[y, x] = 0;
                    }
                }
            }
        } while (flashed);

        /*

        Console.WriteLine($"After step {i + 1}:");
        var col = Console.ForegroundColor;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Console.ForegroundColor = flashes[y, x] ? ConsoleColor.Yellow : ConsoleColor.DarkGray;
                Console.Write(energy[y, x]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        */
    }
    Console.WriteLine(flasCount);
}

void Puzzle2(int[,] energy)
{
    long step = 0;
    while(true)
    {
        bool[,] flashes = new bool[10, 10];
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                energy[y, x] += 1;
            }
        }

        bool flashed = false;
        do
        {
            flashed = false;
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (energy[y, x] > 9)
                    {
                        flashed = true;
                        flashes[y, x] = true;
                        foreach (var point in new Point(x, y).Neighbours)
                        {
                            if (!flashes[point.Y, point.X])
                            {
                                energy[point.Y, point.X] += 1;
                            }
                        }
                        energy[y, x] = 0;
                    }
                }
            }
        } while (flashed);
        step++;

        Console.WriteLine($"After step {step}:");
        var col = Console.ForegroundColor;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Console.ForegroundColor = flashes[y, x] ? ConsoleColor.Yellow : ConsoleColor.DarkGray;
                Console.Write(energy[y, x]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        bool allFlashed = true; 
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (!flashes[y,x])
                {
                    allFlashed = false;
                    break;
                }
            }
            if (!allFlashed)
            {
                break;
            }
        } 
        


        if (allFlashed)
        {
            Console.WriteLine(step);
            return;
        }
        else
        {
            if (step % 100 == 0)
            {
                Console.WriteLine(step);
            }
        }
    }
}

int[,] ReadInput(string fileName)
{
    var lines = System.IO.File.ReadAllLines(fileName);
    var result = new int[10,10];

    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            result[i,j] = Int32.Parse(lines[i][j].ToString());
        }
    }
    return result;
}
