using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class InlineQuery
    {
        public string Id { get; set; }
        public User From { get; set; }
        public string Query { get; set; }
        public string Offset { get; set; }
        public string Chat_type { get; set; }
        public Location Location { get; set; }
    }
}
