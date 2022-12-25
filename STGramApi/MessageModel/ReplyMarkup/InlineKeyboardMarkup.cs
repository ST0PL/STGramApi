using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModel.ReplyMarkup
{
    public class InlineKeyboardMarkup
    {
        public InlineKeyboardButton[][] inline_keyboard { get; set; }
    }
}
