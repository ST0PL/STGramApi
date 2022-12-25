using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGramApi.MessageModel
{
    public class From : BaseMessageComponents
    {
        public bool Is_bot { get; set; }
        public string Username { get; set; }
    }
}
