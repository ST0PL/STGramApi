using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using STGramApi.MessageModels;
using System.Globalization;
using System.Text;
using static System.Web.HttpUtility;
using STGramApi.MessageModels.ReplyMarkup;
using System.Collections.Generic;

namespace STGramApi
{
    //Класс, включающий себя методы для отправки запросов на сервера Telegram (см. документацию https://core.telegram.org/bots/)
    public static class MessagesRequest
    {
        static HttpClient client = new HttpClient();
        static string ApiUrl;
        static JsonSerializerSettings JSS = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
        static WebRequest Request;

        [Obsolete]
        public static Message SendMessage(this STGram api, long chat_id, string message_text, int reply_to_message_id = 0, string parse_mode="",
            InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup ;
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&text={UrlEncode(message_text)}" +
                $"&reply_to_message_id={reply_to_message_id}&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}");
            
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                    Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                    return message;
                }
            }
        }
        public static async Task<Message> SendMessageAsync(
            this STGram api,
            long chat_id,
            string message_text,
            int reply_to_message_id = 0,
            string parse_mode = "",
            InlineKeyboardMarkup reply_markup = null)
        {
            ApiUrl = $"{STGram.API}{api.Token}/SendMessage";
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            var requestObject = new
            {
                chat_id = chat_id,
                text = message_text,
                reply_to_message_id = reply_to_message_id,
                parse_mode = parse_mode,
                reply_markup = JsonConvert.SerializeObject(reply_markup,JSS)
            };
            FormUrlEncodedContent content = new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string,string>>(JsonConvert.SerializeObject(requestObject,JSS)));
            using (var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl))
            {
                request.Content = content;
                using (var response =  await client.SendAsync(request))
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    JObject keyValuePairs = JObject.Parse(resultString);
                    return JsonConvert.DeserializeObject<Message>(keyValuePairs["result"].ToString());
                }
            }
        }

        public static async Task<bool> PinChatMessageAsync(
            this STGram api,
            long chat_id,
            long message_id,
            bool disable_notification = false)
        {
            var requestObject = new
            {
                chat_id = chat_id,
                message_id = message_id,
                disable_notification = disable_notification
            };
            ApiUrl = $"{STGram.API}{api.Token}/pinChatMessage";
            FormUrlEncodedContent content = new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(requestObject, JSS)));
            using (var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl))
            {
                request.Content = content;
                using (var response = await client.SendAsync(request))
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    JObject keyValuePairs = JObject.Parse(resultString);
                    return bool.Parse(keyValuePairs["result"].ToString());
                }
            }
        }
        public static async Task<bool> UnPinChatMessageAsync(this STGram api, long chat_id, long message_id)
        {
            var requestObject = new
            {
                chat_id = chat_id,
                message_id = message_id,
            };
            ApiUrl = $"{STGram.API}{api.Token}/UnpinChatMessage";
            FormUrlEncodedContent content = new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(requestObject, JSS)));
            using (var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl))
            {
                request.Content = content;
                using (var response = await client.SendAsync(request))
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    JObject keyValuePairs = JObject.Parse(resultString);
                    return bool.Parse(keyValuePairs["result"].ToString());
                }
            }
        }
        public static async Task<User> GetMeAsync(this STGram api)
        {
            string uri = $"{STGram.API}{api.Token}/getMe";
            Request = WebRequest.Create(uri);
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject JsonObject = JObject.Parse(await sr.ReadToEndAsync());
                    User user = JsonConvert.DeserializeObject<User>(JsonObject["result"].ToString());
                    return user;
                }
            }
        }

        public static async Task<Message> SendDocumentAsync(
            this STGram api, 
            long chat_id,
            string document,
            int reply_to_message_id = 0,
            string caption = "",
            string parse_mode = "",
            InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            var requestObject = new
            {
                chat_id = chat_id,
                reply_to_message_id = reply_to_message_id,
                parse_mode = parse_mode,
                caption = caption, 
                reply_markup = JsonConvert.SerializeObject(reply_markup, JSS)
            };
            FormUrlEncodedContent dataContent = new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string,string>>(JsonConvert.SerializeObject(requestObject,JSS)));
            ApiUrl = $"{STGram.API}{api.Token}/SendDocument";
            using (MultipartFormDataContent content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
            {
                using (FileStream fs = System.IO.File.OpenRead(document))
                {
                    StreamContent streamContent = new StreamContent(fs);
                    streamContent.Headers.Add("Content-Disposition", new string(Encoding.UTF8.GetBytes($"form-data; name=\"document\"; filename=\"{Path.GetFileName(document)}\"").Select(b => (char)b).ToArray()));
                    content.Add(streamContent);
                    using (var msg = await client.PostAsync(ApiUrl, content))
                    {
                        JObject jsonObject = JObject.Parse(await msg.Content.ReadAsStringAsync());
                        Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"]?.ToString());
                        return message;
                    }
                }
            }
        }
        public static async Task<Message> SendPhotoAsync(this STGram api, long chat_id, string photo, string caption = "", string parse_mode = "", InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            string uri = $"{STGram.API}{api.Token}/SendPhoto?chat_id={chat_id}&caption={caption}&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}";
            using (HttpClient client = new HttpClient())
            {
                using (MultipartFormDataContent content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
                {
                    using (FileStream fs = System.IO.File.OpenRead(photo))
                    {
                        content.Add(new StreamContent(fs), "photo", Path.GetFileName(photo));
                        using (var msg = await client.PostAsync(uri, content))
                        {
                            JObject jsonObject = JObject.Parse(await msg.Content.ReadAsStringAsync());
                            Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                            return message;
                        }
                    }
                }
            }
        }
        public static async Task<Message> SendVideoAsync(this STGram api, long chat_id, string video, string caption = "", string parse_mode = "", InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string uri = $"{STGram.API}{api.Token}/SendVideo?chat_id={chat_id}&caption={caption}&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}";
            using (MultipartFormDataContent content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
            {
                using (FileStream fs = System.IO.File.OpenRead(video))
                {
                    content.Add(new StreamContent(fs), "video", Path.GetFullPath(video));
                    using (var msg = await client.PostAsync(uri, content))
                    {
                        JObject jsonObject = JObject.Parse(await msg.Content.ReadAsStringAsync());
                        Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                        return message;
                    }
                }
            }
        }
        public static async Task<Message> SendAudioAsync(this STGram api, long chat_id, string audio, string caption = "", string parse_mode = "", InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            string uri = $"{STGram.API}{api.Token}/SendAudio?chat_id={chat_id}&caption={UrlEncode(caption)}&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}";
            using (HttpClient client = new HttpClient())
            {
                using (MultipartFormDataContent content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
                {
                    using (FileStream fs = System.IO.File.OpenRead(audio))
                    {
                        content.Add(new StreamContent(fs), "audio", Path.GetFileName(audio));
                        using (var msg = await client.PostAsync(uri, content))
                        {
                            JObject jsonObject = JObject.Parse(await msg.Content.ReadAsStringAsync());
                            Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                            return message;
                        }
                    }
                }
            }
        }
        public static Message EditMessageText(this STGram api, long chat_id, long message_id, string message_text, string parse_mode = "", InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&message_id={message_id}&text={UrlEncode(message_text)}&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}");
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                    Message result = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                    return result;

                }
            }
        }
        public static void EditMessageReplyMarkup(this STGram api, long chat_id=0, long message_id=0, string inline_message_id="", InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&message_id={message_id}&inline_message_id={inline_message_id}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}");
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                }
            }
        }
        public static void AnswerCallbackQuery(this STGram api, string CallbackQueryId, string text="", bool show_alert=false, string url="", int cache_time=0)
        {
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?callback_query_id={CallbackQueryId}&text={text}&show_alert={show_alert}&url={url}&cache_time={cache_time}");
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                }
            }
        }
        public static void DeleteMessage(this STGram api,long chat_id, long message_id)
        {
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&message_id={message_id}");
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                }
            }
        }
        public static Message ForwardMessage(this STGram api, long chat_id, long from_chat_id, long message_id)
        {
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&from_chat_id={from_chat_id}&message_id={message_id}");
            Request.Proxy = null;
            {
                using (Stream stream = Request.GetResponse().GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                        Message Result = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                        return Result;
                    }
                }
            }
        }
        public static MessageModels.File GetFile(this STGram api, string file_id)
        {
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?file_id={file_id}");
            Request.Proxy = null;
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                    MessageModels.File file = JsonConvert.DeserializeObject<MessageModels.File>(jsonObject["result"].ToString());
                    return file;
                }
            }
        }
        public static void DownloadFile(this STGram api, string file_path, string path)
        {
            Uri uri = new Uri($"{STGram.API_FILE}{api.Token}/{file_path}");
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(uri, path);
            }
        }
    }
}
