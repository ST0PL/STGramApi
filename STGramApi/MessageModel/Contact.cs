using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Contact
    {
        public string Phone_number { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public long User_id { get; set; }
        public string Vcard { get; set; }
    }
}
