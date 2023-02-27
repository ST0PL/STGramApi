using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Document : BaseDocumentComponents
    {
        public PhotoSize Thump { get; set; } = new PhotoSize();
        public string File_Name { get; set; }
        public string Mime_Type { get; set; }
    }
}
