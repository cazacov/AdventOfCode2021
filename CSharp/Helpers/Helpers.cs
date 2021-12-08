namespace AocHelpers
{
    public static class Helpers
    {
        public static List<int> ReadInts(string fileName)
        {
            return File.ReadAllLines(fileName).ToList().ConvertAll(x => int.Parse(x));
        }

        public static List<int> ReadCsvInts(string fileName)
        {
            return File.ReadAllText(fileName).Split(",").ToList().ConvertAll(x => int.Parse(x));
        }

        public static string SortCharacters(string x)
        {
            var chars = x.ToCharArray().ToList();
            chars.Sort();
            return new string(chars.ToArray());
        }

        public static List<string> ReadStrings(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }

        public static string SubtractStrings(string str1, string str2)
        {
            var chars = str2.ToCharArray();

            var result = "";
            foreach (var ch in str1)
            {
                if (!chars.Contains(ch))
                {
                    result += ch;
                }
            }
            return result;
        }
    }
}