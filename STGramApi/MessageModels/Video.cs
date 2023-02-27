using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Video : BaseDocumentComponents
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public PhotoSize Thumb { get; set; }
        public string File_name { get; set; }
        public string Mime_type { get; set; }
        public string Caption { get; set; }
    }
}
