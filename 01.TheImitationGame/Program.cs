/*
 
zzHe
ChangeAll|z|l
Insert|2|o
Move|3
Decode
owyouh
Move|2
Move|3
Insert|3|are
Insert|9|?
Decode

*/
namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = "";
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] token = input.Split('|');
                switch (token[0])
                {
                    case "Move":
                        message = MoveLettersToBack(message, int.Parse(token[1]));
                        break;
                    case "Insert":
                        message = message.Insert(int.Parse(token[1]), token[2]);
                        break;
                    case "ChangeAll":
                        if (message.Contains(token[1]))
                        {
                            message = message.Replace(token[1], token[2]);
                        }
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");

        }
        static string MoveLettersToBack(string key, int n)
        {
            string firstNLetters = key.Substring(0, n);
            string remainingLetters = key.Substring(n);

            key = remainingLetters + firstNLetters;
            return key;
        }
    }
}
