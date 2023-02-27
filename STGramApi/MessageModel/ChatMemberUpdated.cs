using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ChatMemberUpdated<T1,T2>
    {
        public Chat Chat { get; set; }
        public User From { get; set; }
        public int Date { get; set; }
        public T1 Old_chat_member { get; set; }
        public T2 New_chat_member { get; set; }
        public ChatInviteLink Invite_link { get; set; }

    }
}
