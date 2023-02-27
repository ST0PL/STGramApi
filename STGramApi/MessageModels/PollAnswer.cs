using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class PollAnswer
    {
        public string Poll_id { get; set; }
        public User User { get; set; }
        public List<int> Option_ids { get; set; }
    }
}
