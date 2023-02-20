using STGramApi.MessageModels.ReplyMarkup;

namespace STGramApi.MessageModels
{
    public class Message
    {
        public int Message_id { get; set; }
        public Chat Chat { get; set; }
        public Chat Sender_chat { get; set; }
        public From From { get; set; }
        public User Forward_from { get; set; }
        public Chat Forward_from_chat { get; set; }
        public long Forward_from_message_id { get; set; }
        public string Forward_signature { get; set; }
        public string Forward_sender_name { get; set; }
        public long Forward_date { get; set; }
        public bool Is_topic_message { get; set; }
        public bool Is_automatic_forward { get; set; }
        public User Via_bot { get; set; }
        public long Edit_date { get; set; }
        public bool Has_protected_content { get; set; }
        public Audio Audio { get; set; }
        public Video Video { get; set; }
        public string Text { get; set; }
        public string Caption { get; set; }
        public long Date { get; set; }
        public Document Document { get; set; }
        public InlineKeyboardMarkup Reply_markup { get; set; }
    }
}
