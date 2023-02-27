using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ChatJoinRequest
    {
        public Chat Chat { get; set; }
        public User From { get; set; }
        public int User_chat_id { get; set; }
        public int Date { get; set; }
        public string Bio { get; set; }
        public ChatInviteLink Invite_link { get; set; }
    }
}
