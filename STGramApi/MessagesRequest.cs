using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using STGramApi.MessageModel;
using System.Globalization;
using System.Text;
using static System.Web.HttpUtility;
using STGramApi.MessageModel.ReplyMarkup;

namespace STGramApi
{
    //Класс, включающий себя методы для отправки запросов на сервера Telegram (см. документацию https://core.telegram.org/bots/)

    //Все запросы, за исключением тех, что отправляют файлы, используют HTTP метод GET
    public static class MessagesRequest
    {
        static JsonSerializerSettings JSS = new JsonSerializerSettings
        {
            //Игнорирование при сериализации полей объекта, обладающих значением null
            NullValueHandling = NullValueHandling.Ignore
        };
        static WebRequest Request;
        public static Message SendMessage(this STGram api, long chat_id, string message_text, int reply_to_message_id = 0, string parse_mode="",
                                          InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup ;
            string Method = MethodBase.GetCurrentMethod().Name;
            //Создание объекта запроса, включающего строку GET запроса
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&text={UrlEncode(message_text)}" +
                $"&reply_to_message_id={reply_to_message_id}&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}");
            
            //Отправка запроса на сервер и получение потока ответа
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                //Чтение потока ответа
                using (StreamReader sr = new StreamReader(stream))
                {
                    //Преобразование строки ответа в JObject Для дальнейшей обработки
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                    //Преобразование строки JSON в объект класса Message, содержащий данные об отправленном запросе, для дальнейшего возвращения пользователю
                    Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"].ToString());
                    //Возвращение объекта класса Message
                    return message;
                }
            }
        }

        public static async Task<Message> SendDocumentAsync(this STGram api, long chat_id, string document, int reply_to_message_id = 0, string caption = "",
                                                            string parse_mode = "",
                                                            InlineKeyboardMarkup reply_markup = null)
        {
            //Проверка наличия кнопок клавиатуры reply_markup
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            //Получение названия выполняемого метода для дальнейшего подставления в строку запроса
            string Method = MethodBase.GetCurrentMethod().Name;
            string uri = $"{STGram.API}{api.Token}/SendDocument?chat_id={chat_id}&reply_to_message_id={reply_to_message_id}&caption={caption}" +
                "&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}";
            using (HttpClient client = new HttpClient())
            {
                //Создание объекта для формы Multipart/form-data
                using (MultipartFormDataContent content = new MultipartFormDataContent($"Upload----{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"))
                {
                    //Получение потока файлы
                    using (FileStream fs = System.IO.File.OpenRead(document))
                    {
                        //Упаковка потока файла в streamcontent
                        StreamContent streamContent = new StreamContent(fs);
                        //Добавление в запрос заголовка, содаржащего название файлы, дату, и путь
                        streamContent.Headers.Add("Content-Disposition", new string(Encoding.UTF8.GetBytes($"form-data; name=\"document\"; filename=\"{Path.GetFileName(document)}\"").Select(b => (char)b).ToArray()));
                        //Добавление streamcontent в качестве контента запроса
                        content.Add(streamContent);
                        //Выполение POST запроса
                        using (var msg = await client.PostAsync(uri, content))
                        {
                            JObject jsonObject = JObject.Parse(await msg.Content.ReadAsStringAsync());
                            Message message = JsonConvert.DeserializeObject<Message>(jsonObject["result"]?.ToString());
                            return message;
                        }
                    }
                }
            }
        }
        public static async Task<Message> SendPhotoAsync(this STGram api, long chat_id, string photo, string caption = "", string parse_mode = "",
                                                         InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            string uri = $"{STGram.API}{api.Token}/SendPhoto?chat_id={chat_id}&caption={caption}&parse_mode={parse_mode}" +
                "&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}";
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
        public static async Task<Message> SendAudioAsync(this STGram api, long chat_id, string audio, string caption = "", string parse_mode = "",
                                                         InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            string uri = $"{STGram.API}{api.Token}/SendAudio?chat_id={chat_id}&caption={UrlEncode(caption)}&parse_mode={parse_mode}" +
                "&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}";
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
        public static void EditMessageText(this STGram api, long chat_id, long message_id, string message_text, string parse_mode = "",
                                           InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&message_id={message_id}&text={UrlEncode(message_text)}" +
                                        "&parse_mode={parse_mode}&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}");
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                }
            }
        }
        public static void EditMessageReplyMarkup(this STGram api, long chat_id=0, long message_id=0, string inline_message_id="",
                                                  InlineKeyboardMarkup reply_markup = null)
        {
            reply_markup = reply_markup == null ? new InlineKeyboardMarkup() : reply_markup;
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?chat_id={chat_id}&message_id={message_id}&inline_message_id={inline_message_id}" +
                                        "&reply_markup={UrlEncode(JsonConvert.SerializeObject(reply_markup, JSS))}");
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
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?callback_query_id={CallbackQueryId}" +
                                        "&text={text}&show_alert={show_alert}&url={url}&cache_time={cache_time}");
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
        public static string ForwardMessage(this STGram api, long chat_id, long from_chat_id, long message_id)
        {
            string Method = MethodBase.GetCurrentMethod().Name;
            return "x";
        }
        public static MessageModel.File GetFile(this STGram api, string file_id)
        {
            string Method = MethodBase.GetCurrentMethod().Name;
            Request = WebRequest.Create($"{STGram.API}{api.Token}/{Method}?file_id={file_id}");
            Request.Proxy = null;
            using (Stream stream = Request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    JObject jsonObject = JObject.Parse(sr.ReadToEnd());
                    MessageModel.File file = JsonConvert.DeserializeObject<MessageModel.File>(jsonObject["result"].ToString());
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
