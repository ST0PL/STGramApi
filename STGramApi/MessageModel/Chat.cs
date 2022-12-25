using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGramApi.MessageModel
{
    public class Chat : BaseMessageComponents
    {
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
