using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ChatPhoto
    {
        public string Small_file_id { get; set; }
        public string Small_file_unique_id { get; set; }
        public string Big_file_id { get; set; }
        public string Big_file_unique_id { get; set; }
    }
}
