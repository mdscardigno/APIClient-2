using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
                var title = PromptForInput($"What song, from {artist} do you want to search for?");
                Console.WriteLine($"Searching for {title} by {artist}...");

                await SearchLyrics(artist, title);

                var input = PromptForInput("Would you like to search for another song? (y/n)").ToUpper();
                keepGoing = input == "Y" ? true : false;

            }
        }

        //helper method
        static string PromptForInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        //setting up the API call
        static async Task SearchLyrics(string artist, string title)
        {
            try
            {
                var client = new HttpClient();

                var url = $"https://api.lyrics.ovh/v1/{artist}/{title}";

                var responseBodyAsStream = await client.GetStreamAsync(url);

                Lyrics lyricsObj = await JsonSerializer.DeserializeAsync<Lyrics>(responseBodyAsStream);

                var table = new ConsoleTable("Artist", "Title", "Lyrics");
                table.AddRow(artist, title, lyricsObj.SongLyrics);
                table.Write();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Please try again.");
                Console.WriteLine(e.Message);
                return;
            }

        }
    }
}
