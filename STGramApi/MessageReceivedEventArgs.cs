using System;
using System.Collections.Generic;
using System.Text;
using STGramApi.MessageModel;

namespace STGramApi
{

    //Ивент, вызываемый при обнаружении поллингом нового сообщения. (не завершён)
    public class MessageRecievedEventArgs
    {

        public Message PollingMessage { get; private set; }

        public MessageRecievedEventArgs(Message e)
        {
            PollingMessage = e;
        }
    }
}
