using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STGramApi.MessageModel.ReplyMarkup;

namespace STGramApi.MessageModel
{
    public class Message
    {
        public long Message_id { get; set; }
        public Chat Chat { get; set; } = new Chat();
        public From From { get; set; } = new From();
        public string Text { get; set; }
        public long Date { get; set; }
        public Document Document { get; set; } = new Document();
        public InlineKeyboardMarkup Reply_markup { get; set; }
    }
}
