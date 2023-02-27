using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ShippingAddress
    {
        public string Country_code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string street_line1 { get; set; }
        public string street_line2 { get; set; }
        public string Post_code { get; set; }
    }
}
