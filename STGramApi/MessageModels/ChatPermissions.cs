using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ChatPermissions
    {
        public bool can_send_messages { get; set; }
        public bool can_send_audios { get; set; }
        public bool can_send_documents { get; set; }
        public bool can_send_photos { get; set; }
        public bool can_send_videos { get; set; }
        public bool can_send_video_notes { get; set; }
        public bool can_send_voice_notes { get; set; }
        public bool can_send_polls { get; set; }
        public bool can_send_other_messages { get; set; }
        public bool can_add_web_page_previews { get; set; }
        public bool can_change_info { get; set; }
        public bool can_invite_users { get; set; }
        public bool can_pin_messages { get; set; }
        public bool can_manage_topics { get; set; }
    }
}
