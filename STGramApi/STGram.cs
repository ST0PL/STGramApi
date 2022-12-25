using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace STGramApi
{
    //Главный класс, через объект которого будут выполняться запросы
    public class STGram
    {
        public string Token { get; private set; }
        public const string API = "https://api.telegram.org/bot";
        public const string API_FILE = "https://api.telegram.org/file/bot";

        public STGram(string token)
        {
            Token = token;
        }
    }
}
