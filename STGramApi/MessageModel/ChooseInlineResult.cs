using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ChooseInlineResult
    {
        public string Result_id { get; set; }
        public User From { get; set; }
        public Location Location { get; set; }
        public string Inline_message_id { get; set; }
        public string Query { get; set; }
    }
}
