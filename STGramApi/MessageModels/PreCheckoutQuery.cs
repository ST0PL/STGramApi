using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class PreCheckoutQuery
    {
        public string Id { get; set; }
        public User From { get; set; }
        public string Currency { get; set; }
        public int Total_amount { get; set; }
        public string Invoice_payload { get; set; }
        public string Shipping_option_id { get; set; }
        public OrderInfo Order_info { get; set; }
    }
}
