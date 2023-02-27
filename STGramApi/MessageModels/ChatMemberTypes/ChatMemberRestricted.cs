using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels.ChatMemberTypes
{
    public class ChatMemberRestriced : ChatMemberBase
    {
        public bool Is_member { get; set; }
        public bool Can_send_messages { get; set; }
        public bool Can_send_audios { get; set; }
        public bool Can_send_documents { get; set; }
        public bool Can_send_photos { get; set; }
        public bool Can_send_videos { get; set; }
        public bool Can_send_video_notes { get; set; }
        public bool Can_send_voice_notes { get; set; }
        public bool Can_send_polls { get; set; }
        public bool Can_send_other_messages { get; set; }
        public bool Can_add_web_page_previews { get; set; }
        public bool Can_change_info { get; set; }
        public bool Can_invite_users { get; set; }
        public bool Can_pin_messages { get; set; }
        public bool Can_manage_topics { get; set; }
        public int Until_date { get; set; }
    }
}
