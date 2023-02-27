using STGramApi.MessageModels.ReplyMarkup;
using System.Collections.Generic;

namespace STGramApi.MessageModels
{
    public class Message
    {
        public int Message_id { get; set; }
        public int Message_thread_id { get; set; }
        public User From { get; set; }
        public Chat Sender_chat { get; set; }
        public int Date { get; set; }
        public Chat Chat { get; set; }
        public User Forward_from { get; set; }
        public Chat Forward_from_chat { get; set; }
        public int Forward_from_message_id { get; set; }
        public string Forward_signature { get; set; }
        public string Forward_sender_name { get; set; }
        public int Forward_date { get; set; }
        public bool Is_topic_message { get; set; }
        public bool Is_automatic_forward { get; set; }
        public Message Reply_to_message { get; set; }
        public User Via_bot { get; set; }
        public int Edit_date { get; set; }
        public bool Has_protected_content { get; set; }
        public string Media_group_id { get; set; }
        public string Author_signature { get; set; }
        public string Text { get; set; }
        public List<MessageEntity> Entities { get; set; }
        public Animation Animation { get; set; }
        public Audio Audio { get; set; }
        public Document Document { get; set; }
        public List<PhotoSize> Photo { get; set; }
        public Sticker Sticker { get; set; }
        public Video Video { get; set; }
        public VideoNote Video_note { get; set; }
        public Voice Voice { get; set; }
        public string Caption { get; set; }
        public List<MessageEntity> Caption_entities { get; set; }
        public bool Has_media_spoiler { get; set; }
        public Contact Contact { get; set; }
        public Dice Dice { get; set; }
        public Game Game { get; set; }
        public Poll Poll { get; set; }
        public Venue Venue { get; set; }
        public Location Location { get; set; }
        public List<User> New_chat_members { get; set; }
        public User Left_chat_member { get; set; }
        public string New_chat_title { get; set; }
        public List<PhotoSize> New_chat_photo { get; set; }
        public bool Delete_chat_photo { get; set; }
        public bool Group_chat_created { get; set; }
        public bool Supergroup_chat_created { get; set; }
        public bool Channel_chat_created { get; set; }
        public InlineKeyboardMarkup Reply_markup { get; set; }
    }
}
