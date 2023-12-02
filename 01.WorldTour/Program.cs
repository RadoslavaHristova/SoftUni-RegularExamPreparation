/*
Hawai::Cyprys-Greece
Add Stop:7:Rome
Remove Stop:11:16
Switch:Hawai:Bulgaria
Travel

 */
using static System.Net.Mime.MediaTypeNames;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string input = "";
            while((input=Console.ReadLine()) != "Travel") 
            {
                string[] token = input.Split(':');
                switch (token[0]) 
                {
                    case "Add Stop":
                        stops = AddStop(stops, token);
                        break;
                    case "Remove Stop":
                        stops = RemoveStop(stops, token);
                        break;
                    case "Switch":
                        stops = Switch(stops, token);
                        break;
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        private static string Switch(string stops, string[] token)
        {
            if (stops.Contains(token[1]))
            {
                stops = stops.Replace(token[1], token[2]);
            }
            Console.WriteLine(stops);
            return stops;
        }

        private static string RemoveStop(string stops, string[] token)
        {
            int start = int.Parse(token[1]), end = int.Parse(token[2]);
            if (start >= 0 && end < stops.Length && start <= end)
            {
                stops = stops.Remove(start, end - start + 1);
            }
            Console.WriteLine(stops);
            return stops;
        }

        private static string AddStop(string stops, string[] token)
        {
            if (int.Parse(token[1]) < stops.Length && int.Parse(token[1]) >= 0)
            {
                stops = stops.Insert(int.Parse(token[1]), token[2]);
            }
            Console.WriteLine(stops);
            return stops;
        }
    }
}
