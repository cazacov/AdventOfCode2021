internal class Board
{
    private bool[,] AreMarked = new bool[5,5];
    private int [,] Numbers = new int[5,5];

    public Board(List<int> numbers)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Numbers[i, j] = numbers[i * 5 + j];
            }
        }
    }

    internal void Mark(int n)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Numbers[i, j] == n)
                {
                    AreMarked[i, j] = true;
                }
            }
        }
    }

    internal bool HasWon()
    {
        for (int i = 0; i < 5; i++)
        {
            bool row = true;
            bool column = true;
            for (int j = 0; j < 5; j++)
            {
                row &= AreMarked[i, j];
                column &= AreMarked[j, i];
            }
            if (row || column)
            {
                return true;
            }
        }
        return false;
    }

    internal int Score
    {
        get
        {
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!AreMarked[i, j])
                    {
                        score += Numbers[i, j];
                    }
                }
            }
            return score;
        }
    }

    internal void Reset()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                AreMarked[i, j] = false;
            }
        }
    }
}