using System;
using System.Collections.Generic;
using System.Text;

namespace STGramApi.MessageModels
{
    public class BaseDocumentComponents 
    {
        public string File_Id { get; set; }
        public string File_Unique_Id { get; set; }
        public int File_Size { get; set; }
    }
}
