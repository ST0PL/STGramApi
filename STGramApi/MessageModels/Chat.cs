using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGramApi.MessageModels
{
    public class Chat : BaseMessageComponents
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public string Last_name { get; set; }
        public bool Is_forum { get; set; }
        public ChatPhoto Photo { get; set; }
        public List<string> Active_usernames { get; set; }
        public string Emoji_status_custom_emoji_id { get; set; }
        public string Bio { get; set; }
        public bool Has_private_forwards { get; set; }
        public bool Has_restricted_voice_and_video_messages { get; set; }
        public bool Join_to_send_messages { get; set; }
        public bool Join_by_request { get; set; }
        public string Description { get; set; }
        public string Invite_link { get; set; }
        public Message Pinned_message { get; set; }
        public ChatPermissions Permissions { get; set; }
        public int Slow_mode_delay { get; set; }
        public int Message_auto_delete_time { get; set; }
        public bool Has_aggressive_anti_spam_enabled { get; set; }
        public bool Has_hidden_members { get; set; }
        public bool Has_protected_content { get; set; }
        public string Sticker_set_name { get; set; }
        public bool Can_set_sticker_set { get; set; }
        public int Linked_chat_id { get; set; }
        public ChatLocation Location { get; set; }


    }
}
