using System;
using System.Collections.Generic;
using System.Text;
using STGramApi.MessageModels.ChatMemberTypes;

namespace STGramApi.MessageModels
{
    public class Update<T1,T2,T3,T4> 
    {
        public int Update_id { get; set; }
        public Message Message { get; set; }
        public Message Edited_message { get; set; }
        public Message Channel_post { get; set; }
        public Message Edited_channel_post { get; set; }
        public InlineQuery InlineQuery { get; set; }
        public ChooseInlineResult Chosen_inline_result { get; set; }
        public CallbackQuery callback_query { get; set; }
        public ShippingQuery shipping_query { get; set; }
        public PreCheckoutQuery pre_checkout_query { get; set; }
        public Poll Poll { get; set; }
        public PollAnswer Poll_answer { get; set; }
        public ChatMemberUpdated<T1,T2> My_chat_member { get; set; }
        public ChatMemberUpdated<T3,T4> Chat_member { get; set; }
        public ChatJoinRequest Chat_join_request { get; set; }

    }
}
