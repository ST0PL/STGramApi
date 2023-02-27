using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels.ChatMemberTypes
{
    public class ChatMemberOwner : ChatMemberBase
    {
        public bool Is_anonymous { get; set; }
        public string Custom_title { get; set; }
    }
}
