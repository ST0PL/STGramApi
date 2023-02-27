using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels.ChatMemberTypes
{
    public class ChatMemberBanned : ChatMemberBase
    {
        public int Until_date { get; set; }
    }
}
