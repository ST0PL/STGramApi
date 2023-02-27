using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class OrderInfo
    {
        public string Name { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public ShippingAddress Shipping_address { get; set; }
    }
}
