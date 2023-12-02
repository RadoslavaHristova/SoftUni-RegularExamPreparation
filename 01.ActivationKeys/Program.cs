/*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF
Generate

 */
using System.Data.SqlTypes;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey=Console.ReadLine();
            string input = "";
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] token = input.Split(">>>");
                
                switch (token[0])
                {
                    case "Contains":
                        if (activationKey.Contains(token[1]))
                        { Console.WriteLine($"{activationKey} contains {token[1]}"); }
                        else 
                        { Console.WriteLine("Substring not found!"); }
                        break;
                    case "Flip":
                        bool toUpperCase = true;
                        if (token[1]=="Lower")
                        { toUpperCase=false; }

                        activationKey = ModifySubstring(activationKey, int.Parse(token[2]), int.Parse(token[3]), toUpperCase);
                        Console.WriteLine( activationKey);
                        break;
                    case "Slice":
                        int count = int.Parse(token[2])-int.Parse(token[1]);
                        activationKey = activationKey.Remove(int.Parse(token[1]),count);
                        Console.WriteLine(activationKey);
                        break;
                }
            }


            Console.WriteLine($"Your activation key is: {activationKey}");
        }
        static string ModifySubstring(string key, int startIndex, int stopIndex, bool toUpperCase)
        {
            string substring = key.Substring(startIndex, stopIndex - startIndex);

            if (toUpperCase)
            {
                substring = substring.ToUpper();
            }
            else
            {
                substring = substring.ToLower();
            }

            key = key.Substring(0, startIndex) + substring + key.Substring(stopIndex);
            return key;
        }
    }
}
