using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGramApi.MessageModels
{
    public class From : BaseMessageComponents
    {
        public bool Is_bot { get; set; }
        public string Username { get; set; }
    }
}
