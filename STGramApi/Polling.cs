using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using STGramApi.MessageModels;
using STGramApi;
using Newtonsoft.Json.Linq;
using System.IO;
namespace STGramApi
{
    // В процессе разработки...
    class Item
    {
        public int update_id { get; set; }
    }
    public static class Polling
    {
        static WebRequest Request;
        static StreamReader sr;
        public static event Action<MessageReceivedEventArgs> MessageReceived;
        public async static void StartRecieve(this STGram api)
        {
            List<int> buffer = new List<int>();
            while (true)
            {
                Request = (HttpWebRequest)WebRequest.Create($"{STGram.API}{api.Token}/getUpdates?timeout=10&offset=-1");
                sr = new StreamReader(Request.GetResponse().GetResponseStream());
                var z = sr.ReadToEnd();
                JObject resp = JObject.Parse(z);
                var bag = JsonConvert.DeserializeObject<List<Item>>(resp["result"].ToString());
                if (bag.Count > 0)
                {
                    buffer.Add(bag[0].update_id);
                    break;
                }
            }
            int offset = buffer[0]+1;
            while (true)
            {
                Request = (HttpWebRequest)WebRequest.Create($"{STGram.API}{api.Token}/getUpdates?timeout=10&offset={offset}");
                sr = new StreamReader(Request.GetResponse().GetResponseStream());
                JObject Response = JObject.Parse(sr.ReadToEnd());
                if (Response["result"].HasValues)
                {
                    var ResponseCollection = JsonConvert.DeserializeObject<Message>(Response["result"][0]["message"].ToString());
                    MessageReceived.Invoke(new MessageReceivedEventArgs(ResponseCollection));
                    offset += 1;
                }
            }
        }

        static void GetUpdates(STGram api)
        {
            //Request = WebRequest.Create($"{STGram.API}{api.Token}/getUpdates");
            //using (Stream stream = Request.GetResponse().GetResponseStream())
            //{
            //    using (StreamReader sr = new StreamReader(stream))
            //    {
            //        JObject Response = JObject.Parse(sr.ReadToEnd());
            //        var ResponseArray = Response["result"];
            //        List<Message> PollingList = new List<Message>();
            //        foreach (var item in ResponseArray)
            //        {
            //            PollingList.Add(JsonConvert.DeserializeObject<Message>(item["message"].ToString()));
            //        }
            //        return PollingList;
            //    }
            //}
        }
    }
}
