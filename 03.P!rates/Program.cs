/*
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End

Nassau||95000||1000
San Juan||930000||1250
Campeche||270000||690
Port Royal||320000||1000
Port Royal||100000||2000
Sail
Prosper=>Port Royal=>-200
Plunder=>Nassau=>94000=>750
Plunder=>Nassau=>1000=>150
Plunder=>Campeche=>150000=>690
End

 */
namespace _03.P_rates
{
    internal class Program
    {
        public class City
        {
            private string city;

            public City(string city, int population, int gold)
            {
                Name = city;
                Population = population;
                Gold = gold;
            }

            public int Population { get; set; }
            public int Gold { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, City> list = new Dictionary<string, City>();
            string input = "";
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] token = input.Split("||");
                string city = token[0];
                int population = int.Parse(token[1]);
                int gold = int.Parse(token[2]);

                if (!list.ContainsKey(city))
                {
                    City city1 = new City(city, population, gold);
                    list.Add(city, city1);
                }
                else
                {
                    list[city].Population += population;
                    list[city].Gold += gold;
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split("=>");
                switch (command[0])
                {
                    case "Plunder":

                        Plunder(list, command);
                        break;
                    case "Prosper":
                        Prosper(list, command);
                        break;
                }

            }
            if (list.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {list.Count} wealthy settlements to go to:");
                foreach (var city in list)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            { Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!"); }
        }

        private static void Prosper(Dictionary<string, City> list, string[] command)
        {
            if (int.Parse(command[2]) < 0)
            {
                Console.WriteLine($"Gold added cannot be a negative number!");
            }
            else
            {
                list[command[1]].Gold += int.Parse(command[2]);
                Console.WriteLine($"{int.Parse(command[2])} gold added to the city treasury. {command[1]} now has {list[command[1]].Gold} gold.");
            }
        }

        private static void Plunder(Dictionary<string, City> list, string[] command)
        {
            list[command[1]].Population -= int.Parse(command[2]);
            list[command[1]].Gold -= int.Parse(command[3]);
            Console.WriteLine($"{command[1]} plundered! {int.Parse(command[3])} gold stolen, {int.Parse(command[2])} citizens killed.");

            if (list[command[1]].Population <= 0 || list[command[1]].Gold <= 0)
            {
                Console.WriteLine($"{command[1]} has been wiped off the map!");
                list.Remove(command[1]);
            }
        }
    }
}