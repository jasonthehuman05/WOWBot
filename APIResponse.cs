using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WOWBot
{

    public class Wow
    {
        public string movie { get; set; }
        public int year { get; set; }
        public string release_date { get; set; }
        public string director { get; set; }
        public string character { get; set; }
        public string movie_duration { get; set; }
        public string timestamp { get; set; }
        public string full_line { get; set; }
        public int current_wow_in_movie { get; set; }
        public int total_wows_in_movie { get; set; }
        public string poster { get; set; }
        public Video video { get; set; }
        public string audio { get; set; }
    }

    public class Video
    {
        [JsonProperty("1080p")]
        public string _1080p { get; set; }

        [JsonProperty("720p")]
        public string _720p { get; set; }

        [JsonProperty("480p")]
        public string _480p { get; set; }
        
        [JsonProperty("360p")]
        public string _360p { get; set; }
    }

    public static class Shortener
    {
        public static string ShortenUrl(string URL)
        {
            string newUrl = new HttpClient().GetStringAsync($"https://ulvis.net/api.php?url={URL}").Result;
            Console.WriteLine(newUrl);
            return newUrl;
        }
    }
}
