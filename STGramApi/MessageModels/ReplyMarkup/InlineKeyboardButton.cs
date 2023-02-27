using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace STGramApi.MessageModels.ReplyMarkup
{
    public class InlineKeyboardButton
    {
        public string text { get; set; }
        public string callback_data { get; set; }
        public string url { get; set; }
        public string switch_inline_query { get; set; }

        public void SetText(string text)
        {
            this.text = text;
        }
        public void SetCallbackData(string callback_data)
        {
            this.callback_data = callback_data;
        }
        public void SetUrl(string url)
        {
            this.url = url;
        }
    }
}
