using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class CallbackQuery
    {
        public string Id { get; set; }
        public User From { get; set; }
        public Message Message { get; set; }
        public string Inline_message_id { get; set; }
        public string Chat_instance { get; set; }
        public string Data { get; set; }
        public string Game_short_name { get; set; }
    }
}
