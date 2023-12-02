/*
=Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i=
 */
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
           string input=Console.ReadLine();
            string pattern = @"(=|/)([A-Z]{1}[A-Za-z]{2,})\1";
            int points = 0;
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                points += m.Groups[2].Length;
                list.Add(m.Groups[2].Value);
            }
            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
