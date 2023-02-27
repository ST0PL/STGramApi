using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels.ChatMemberTypes
{
    public class ChatMemberBase
    {
        public string Status { get; set; }
        public User User { get; set; }
    }
}
