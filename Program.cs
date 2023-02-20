using System;
using System.Net.Http;

namespace APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dogs API Client");

            var client = new HttpClient();

            var responseAsString = client.GetStringAsync("https://lyricsovh.docs.apiary.io/#reference/0/lyrics-of-a-song/search");

            Console.WriteLine(responseAsString.Result);
        }
    }
}
