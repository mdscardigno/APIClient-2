using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace APIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Lyric Finder.");

            var keepGoing = true;
            while (keepGoing)
            {
                var artist = PromptForInput("What artist do you want to search for?");
                var song = PromptForInput($"What song, from {artist} do you want to search for?");
                Console.WriteLine($"Searching for {song} by {artist}...");

                await SearchLyrics(artist, song);

            }
        }

        //helper method
        static string PromptForInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        //setting up the API call
        static async Task SearchLyrics(string artist, string song)
        {
            var client = new HttpClient();

            var url = $"https://api.lyrics.ovh/v1/{artist}/{song}";

            var responseBodyAsStream = await client.GetStreamAsync(url);

            //creating a Lyrics object
            Lyrics lyricsObj = await JsonSerializer.DeserializeAsync<Lyrics>(responseBodyAsStream);

            var table = new ConsoleTable("Artist", "Song", "Lyrics");
        }
    }
}
