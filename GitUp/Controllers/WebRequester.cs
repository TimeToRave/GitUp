using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace GitUp.Controllers
{
/// <summary>
    /// Класс для выполнения POST запросов
    /// </summary>
    public class WebRequester
    {
        /// <summary>
        /// Адрес удаленного сервера
        /// </summary>
        public string Url { get; set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="url">Адрес удаленного сервера</param>
        public WebRequester(string url)
        {
            Url = url;
        }


        /// <summary>
        /// Выполняет POST запрос к удаленному серверу
        /// </summary>
        /// <param name="data">Данные для передачи</param>
        /// <param name="timeout">Таймаут для выполнения запроса</param>
        /// <param name="additionalHeaders">Дополнительные заголовки</param>
        /// <returns></returns>
        public string PostRequest(string data, int timeout = 27000,
            Dictionary<string, string> additionalHeaders = default)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Url);

            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            request.Timeout = timeout;

            if (additionalHeaders != null)
            {
                foreach (var additionalHeader in additionalHeaders)
                {
                    request.Headers[additionalHeader.Key] = additionalHeader.Value;
                }
            }

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();

            string responseFromServer;

            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            response.Close();

            return responseFromServer;
        }

        /// <summary>
        /// Выполняет GET запрос к удаленному серверу
        /// </summary>
        /// <returns></returns>
        public string GetRequest(int timeout = 27000, Dictionary<string, string> additionalHeaders = default)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Url);
            request.Timeout = timeout;
            
            
            if (additionalHeaders != null)
            {
                foreach (var additionalHeader in additionalHeaders)
                {
                    request.Headers[additionalHeader.Key] = additionalHeader.Value;
                }
            }
            
            
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return responseFromServer;
        }
    }
}