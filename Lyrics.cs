using System;
using System.Net.Http;
using System.Drawing;
using System.Text.Json.Serialization;
namespace APIClient
{
    public class Lyrics
    {
        [JsonPropertyName("lyrics")]
        public string SongLyrics { get; set; }
    }
}