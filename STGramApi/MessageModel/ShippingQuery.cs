using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class ShippingQuery
    {
        public string Id { get; set; }
        public User From { get; set; }
        public string Invoice_payload { get; set; }
        public ShippingAddress Shipping_address { get; set; }
    }
}
