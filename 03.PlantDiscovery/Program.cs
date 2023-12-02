/*
3
Arnoldii<->4
Woodii<->7
Welwitschia<->2
Rate: Woodii - 10
Rate: Welwitschia - 7
Rate: Arnoldii - 3
Rate: Woodii - 5
Update: Woodii - 5
Reset: Arnoldii
Exhibition

2
Candelabra <->10
Oahu <->10
Rate: Oahu - 7
Rate: Candelabra - 6
Exhibition

 */
namespace _03.PlantDiscovery
{
    internal class Program
    {
        public class Plant
        {
            public string Name { get; set; }
            public int Rarity { get; set; }
            public  List<double> Rating { get; set; } 
            public Plant(string name) 
            {
                Name = name;
                Rating = new List<double>();
            }
            public double  AverageRating()
            {
                if (Rating.Count >0)
                {
                    return Rating.Average();
                }
                else { return 0; }
            }
            public override string ToString()
            {
                
                string result = $"- {Name.TrimEnd()}; Rarity: {Rarity}; Rating: {AverageRating():f2}";
                return result;
            }
            public void AddRating(double rating)
            {
                Rating.Add(rating);
            }
        }
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            Dictionary<string,Plant> collection= new Dictionary<string,Plant>();
            for(int i=0; i<n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("<->")
                    .ToArray();

                CollectPlants(collection, input);
            }
            string token = "";
           
            while((token=Console.ReadLine())!="Exhibition")
            {
                string[] command = token.Split(':');
                string[] arguments=token.Split("-");
                string name = arguments[0].Remove(0, command[0].Length+2).TrimEnd();
                switch(command[0]) 
                {
                    case "Rate":
                        Rate(collection, arguments, name);
                        break;
                    case "Update":
                        Update(collection, arguments, name);
                        break;
                    case "Reset":
                        Reset(collection, name);
                        break;
                }

            }
            Console.WriteLine("Plants for the exhibition:") ;
            foreach(var plant in collection)
            {
                Console.WriteLine(plant.Value.ToString());
            }
        }

        private static void CollectPlants(Dictionary<string, Plant> collection, string[] input)
        {
            if (!collection.ContainsKey(input[0]))
            {
                Plant plant = new Plant(input[0]);
                collection.Add(input[0], plant);
            }
            collection[input[0]].Rarity = int.Parse(input[1]);
        }

        private static void Reset(Dictionary<string, Plant> collection, string name)
        {
            if (collection.ContainsKey(name))
            { collection[name].Rating.Clear(); }
            else
            { PrintError(); }
        }

        private static void Update(Dictionary<string, Plant> collection, string[] arguments, string name)
        {
            if (collection.ContainsKey(name))
            {
                collection[name].Rarity= int.Parse(arguments[1]);
            }
            else
            { PrintError(); }
        }

        private static void Rate(Dictionary<string, Plant> collection, string[] arguments, string name)
        {
            if (collection.ContainsKey(name))
            {
                collection[name].AddRating(double.Parse(arguments[1]));
            }
            else
            {
                PrintError();
            }
        }

        private static void PrintError()
        {
            Console.WriteLine("error");
        }
    }
}
