namespace AocHelpers
{
    public static class Helpers
    {
        public static List<int> ReadInts(string fileName)
        {
            return File.ReadAllLines(fileName).ToList().ConvertAll(x => int.Parse(x));
        }

        public static List<string> ReadStrings(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }
    }
}