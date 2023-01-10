using STGramApi.MessageModel.ReplyMarkup;

namespace STGramApi.MessageModels
{
    public class Message
    {
        public long Message_id { get; set; }
        public Chat Chat { get; set; } = new Chat();
        public Chat Sender_chat { get; set; } = new Chat();
        public From From { get; set; } = new From();
        public User Forward_from { get; set; } = new User();
        public Chat Forward_from_chat { get; set; } = new Chat();
        public long Forward_from_message_id { get; set; }
        public string Forward_signature { get; set; }
        public string Forward_sender_name { get; set; }
        public long Forward_date { get; set; }
        public bool Is_topic_message { get; set; }
        public bool Is_automatic_forward { get; set; }
        public User Via_bot { get; set; } = new User();
        public long Edit_date { get; set; }
        public bool Has_protected_content { get; set; }
        public Audio Audio { get; set; } = new Audio();
        public string Text { get; set; }
        public long Date { get; set; }
        public Document Document { get; set; } = new Document();
        public InlineKeyboardMarkup Reply_markup { get; set; }
    }
}
