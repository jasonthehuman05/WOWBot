using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WOWBot
{
    public static class WowFetcher
    {
        public static List<Wow> GetWow()
        {
            //Code to get the information from the API
            string json = new HttpClient().GetStringAsync("https://owen-wilson-wow-api.onrender.com/wows/random").Result;
            List<Wow> newWow = JsonConvert.DeserializeObject<List<Wow>>(json);
            return newWow;
        }
    }
}
