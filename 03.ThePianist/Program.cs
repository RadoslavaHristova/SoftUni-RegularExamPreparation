/*
3
Fur Elise|Beethoven|A Minor
Moonlight Sonata|Beethoven|C# Minor
Clair de Lune|Debussy|C# Minor
Add|Sonata No.2|Chopin|B Minor
Add|Hungarian Rhapsody No.2|Liszt|C# Minor
Add|Fur Elise|Beethoven|C# Minor
Remove|Clair de Lune
ChangeKey|Moonlight Sonata|C# Major
Stop

4
Eine kleine Nachtmusik|Mozart|G Major
La Campanella|Liszt|G# Minor
The Marriage of Figaro|Mozart|G Major
Hungarian Dance No.5|Brahms|G Minor
Add|Spring|Vivaldi|E Major
Remove|The Marriage of Figaro
Remove|Turkish March
ChangeKey|Spring|C Major
Add|Nocturne|Chopin|C# Minor
Stop

 */
namespace _03.ThePianist
{
    internal class Program
    {
        public class Song
        {
            private string v1;
            private string v2;
            private string v3;

            public Song(string v1, string v2, string v3)
            {
                Name = v1;
                Composer = v2;
                KeyS = v3;
            }

            public string Name { get; set; }
            public string Composer { get; set; }
            public string KeyS { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary <string,Song>playlist=new Dictionary<string,Song>();    

            for(int i=0; i < n; i++) 
            {
                string[] input = Console.ReadLine().Split('|').ToArray();

                if (!playlist.ContainsKey(input[0]))
                {
                    Song song = new Song(input[0],input[1], input[2]);
                    playlist.Add(input[0], song);
                }
            }
            string input1 = "";
           
            while((input1=Console.ReadLine())!="Stop")
            {
                string[] token = input1.Split('|');
                string name= token[1];
                switch (token[0])
                {
                    case "Add":
                        Add(playlist, token, name);
                        break;
                    case "Remove":
                        Remove(playlist, name);
                        break;
                    case "ChangeKey":
                        ChangeKey(playlist, token, name);
                        break;
                }
            }
            foreach(var song in playlist)
            {
                Console.WriteLine($"{song.Key} -> Composer: {song.Value.Composer}, Key: {song.Value.KeyS}");
            }
        }

        private static void ChangeKey(Dictionary<string, Song> playlist, string[] token, string name)
        {
            if (!playlist.ContainsKey(name))
            {
                Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
            }
            else
            {
                playlist[name].KeyS = token[2];
                Console.WriteLine($"Changed the key of {name} to {token[2]}!");
            }
        }

        private static void Remove(Dictionary<string, Song> playlist, string name)
        {
            if (!playlist.ContainsKey(name))
            {
                Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
            }
            else
            {
                playlist.Remove(name);
                Console.WriteLine($"Successfully removed {name}!");
            }
        }

        private static void Add(Dictionary<string, Song> playlist,  string[] token, string name)
        {
            if (!playlist.ContainsKey(name))
            {
                Song newSong = new Song(name, token[2], token[3]);
                playlist.Add(name, newSong);
                Console.WriteLine($"{name} by {token[2]} in {token[3]} added to the collection!");

            }
            else { Console.WriteLine($"{name} is already in the collection!"); }
        }
    }
}
