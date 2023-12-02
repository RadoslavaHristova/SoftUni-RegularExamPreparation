/*
In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 **Tigers**, 1 ::Elephant:, 12 **Monk3ys**, a **Gorilla::, 5 ::fox:es: and 21 different types of :Snak::Es::. ::Mooning:: **Shy**
5, 4, 3, 2, 1, go! The 1-th consecutive banana-eating contest has begun! ::Joy:: **Banana** ::Wink:: **Vali** ::valid_emoji::
 */
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patternEmoji = @"(::|\*\*)([A-Z]{1}[a-z]{2,})\1";
            string patternDigits = @"(\d)";
            int coolThreshold = 1;

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, patternDigits, options))
            {
                int digit = int.Parse(m.Groups[1].Value);
                coolThreshold *= digit;
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");

                int emojiQty = 0;
                List<string> list = new List<string>();

            foreach (Match m in Regex.Matches(input, patternEmoji, options))
            {
                emojiQty++;
                int mCoolnest = 0;
                foreach (char c in m.Groups[2].Value)
                {
                    int asciiValue = Convert.ToInt32(c);
                    mCoolnest += asciiValue;
                }
                if(mCoolnest>=coolThreshold)
                {
                    list.Add(m.Groups[0].Value);
                }
            }
            Console.WriteLine($"{emojiQty} emojis found in the text. The cool ones are:");
            if(list.Count>0) 
            {
            foreach(var coolEmodji in list)
                {
                    Console.WriteLine(coolEmodji);
                }
            }

        }
    }
}

