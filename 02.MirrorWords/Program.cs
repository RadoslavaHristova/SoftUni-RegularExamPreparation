/*
@mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r
 */
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> toPrint = new List<string>();
            List<string> list = new List<string>();

            string input = Console.ReadLine();
            string pattern = @"(@|#)([A-Z a-z]{3,})\1{2}([A-Z a-z]{3,})\1";
            int counter = 0;

            counter = FindPairs(list, input, pattern, counter);

            if (counter == 0)
            { Console.WriteLine("No word pairs found!"); }
            else
            { Console.WriteLine($"{counter} word pairs found!"); }

            if (list.Count == 0)
            { Console.WriteLine("No mirror words!"); }
            else
            {
                PrepMirrorsToPrint(toPrint, list);

                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", toPrint));
            }

        }

        private static void PrepMirrorsToPrint(List<string> toPrint, List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int halfLength = list[i].Length / 2;
                string firstHalf = list[i].Substring(0, halfLength);
                string secondHalf = list[i].Substring(halfLength);
                if (firstHalf.Contains("#"))
                {
                    firstHalf = firstHalf.Trim('#');
                    secondHalf = secondHalf.Trim('#');
                }
                else
                {
                    firstHalf = firstHalf.Trim('@');
                    secondHalf = secondHalf.Trim('@');
                }

                string newString = firstHalf + " " + "<=>" + " " + secondHalf;
                toPrint.Add(newString);
            }
        }

        private static int FindPairs(List<string> list, string input, string pattern, int counter)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                counter++;

                IsMirrorCheck(list, m);
            }

            return counter;
        }

        private static void IsMirrorCheck(List<string> list, Match m)
        {
            int halfLength = m.Length / 2;
            string halfMatch = m.Value.Substring(0, halfLength);

            char[] charArray = halfMatch.ToCharArray();
            Array.Reverse(charArray);
            string reversedHalf = new string(charArray);

            if (reversedHalf == m.Value.Substring(halfLength))
            {
                list.Add(m.Value);
            }
        }
    }
}
