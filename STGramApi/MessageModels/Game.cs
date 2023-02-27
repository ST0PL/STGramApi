using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Game
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PhotoSize> Photo { get; set; }
        public string Text { get; set; }
        public List<MessageEntity> Text_entities { get; set; }
        public Animation Animation { get; set; }
    }
}
