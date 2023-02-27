using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class Voice : BaseDocumentComponents
    {
        public int Duration { get; set; }
        public string Mime_type { get; set; }
    }
}
