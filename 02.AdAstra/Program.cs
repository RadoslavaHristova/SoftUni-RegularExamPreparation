/*
#Bread#19/03/21#4000#|Invalid|03/03.20||Apples|08/10/20|200||Carrots|06/08/20|500||Not right|6.8.20|5|
$$#@@%^&#Fish#24/12/20#8500#|#Incorrect#19.03.20#450|$5*(@!#Ice Cream#03/10/21#9000#^#@aswe|Milk|05/09/20|2000|
 */
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            string pattern = @"(\||#)([A-Za-z]+\s?[A-Za-z]+)\1([0-9]{2}/[0-9]{2}/[0-9]{2})\1([0-9]+)\1";
            int caloriesAtAll = 0;
            int days = 0;
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                caloriesAtAll += int.Parse(m.Groups[4].Value);
            }
            days = caloriesAtAll / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine($"Item: {m.Groups[2].Value}, Best before: {m.Groups[3].Value}, Nutrition: {m.Groups[4].Value}");
            }
        }
    }
}
