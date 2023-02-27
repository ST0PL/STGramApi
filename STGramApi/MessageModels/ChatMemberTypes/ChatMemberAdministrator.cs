using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels.ChatMemberTypes
{
    public class ChatMemberAdministrator : ChatMemberBase 
    {
        public bool Can_be_edited { get; set; }
        public bool Is_anonymous { get; set; }
        public bool Can_manage_chat { get; set; }
        public bool Can_delete_messages { get; set; }
        public bool Can_manage_video_chats { get; set; }
        public bool Can_restrict_members { get; set; }
        public bool Can_promote_members { get; set; }
        public bool Can_change_info { get; set; }
        public bool Can_invite_users { get; set; }
        public bool Can_post_messages { get; set; }
        public bool Can_edit_messages { get; set; }
        public bool Can_pin_messages { get; set; }
        public bool Can_manage_topics { get; set; }
        public string Custom_title { get; set; }
    }
}
