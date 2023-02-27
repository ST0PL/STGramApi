using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ChatInviteLink
    {
        public string Invite_link { get; set; }
        public User Creator { get; set; }
        public bool Creates_join_request { get; set; }
        public bool Is_primary { get; set; }
        public bool Is_revoked { get; set; }
        public string Name { get; set; }
        public int Expire_date { get; set; }
        public int Member_limit { get; set; }
        public int Pending_join_request_count { get; set; }
    }
}
