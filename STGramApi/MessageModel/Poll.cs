using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Poll
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public List<PollOption> Options { get; set; }
        public int Total_voter_count { get; set; }
        public bool Is_closed { get; set; }
        public bool Is_anonymous { get; set; }
        public string Type { get; set; }
        public bool Allows_multiple_answers { get; set; }
        public int Correct_option_id { get; set; }
        public string Explanation { get; set; }
        public List<MessageEntity> Explanation_entities { get; set; }
        public int Open_period { get; set; }
        public int Close_date { get; set; }
    }
}
