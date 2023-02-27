using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class VideoNote : BaseDocumentComponents
    {
        public int Length { get; set; }
        public int Duration { get; set; }
        public PhotoSize Thumb { get; set; }
    }
}
