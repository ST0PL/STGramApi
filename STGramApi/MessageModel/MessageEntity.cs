﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class MessageEntity
    {
        public string Type { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
        public string Language { get; set; }
        public string Custom_emoji_id { get; set; }
    }
}
