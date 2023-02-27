using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Audio : BaseDocumentComponents
    {
        public int Duration { get; set; }
        public string Performer { get; set; }
        public string Title { get; set; }
        public PhotoSize Thump { get; set; } = new PhotoSize();
        public string File_Name { get; set; }
        public string Mime_Type { get; set; }
    }
}
