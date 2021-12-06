using System.Diagnostics;

[DebuggerDisplay("{Days}")]
internal class Fish
{
    public Fish(int days, int cycle)
    {
        Days = days;
        Cycle = cycle;
    }

    public Fish Next()
    {
        this.Days--;
        if (this.Days < 0)
        {
            if (this.Cycle == 7)
            {
                this.Days = Cycle - 1;
            }
            else
            {
                this.Cycle = 7;
                this.Days = Cycle - 1;
            }
            
            return new Fish(this.Cycle + 1, this.Cycle + 2);
        }
        else
        {
            return null;
        }
    }

    public int Days { get; private set; }
    public int Cycle { get; private set; }
}