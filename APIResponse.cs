using System;
using System.Collections.Generic;
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
        public string _1080p { get; set; }
        public string _720p { get; set; }
        public string _480p { get; set; }
        public string _360p { get; set; }
    }

}
