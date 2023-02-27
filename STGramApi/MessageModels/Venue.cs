using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Venue
    {
        public Location Location { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Foursquare_id { get; set; }
        public string Foursquare_type { get; set; }
        public string Google_place_id { get; set; }
        public string Google_place_type { get; set; }
    }
}
