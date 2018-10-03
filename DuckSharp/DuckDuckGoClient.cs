using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using DuckSharp.Converters;
using DuckSharp.Models;
using Newtonsoft.Json;

namespace DuckSharp
{
    public class DuckDuckGoClient
    {
        private readonly string _query;
        private readonly ResponseFormat _format;
        private readonly string _applicationName;
        private readonly bool _noHtml;
        private readonly bool _skipDisambig;
        private readonly bool _noRedirect;
        private readonly int _jsonPretty;

        public DuckDuckGoClient(
            string query,
            ResponseFormat format = ResponseFormat.Json,
            string applicationName = "DuckSharp",
            bool noHtml = false,
            bool skipDisambig = false,
            bool noRedirect = false,
            int jsonPretty = 1)
        {
            _query = query;
            _format = format;
            _applicationName = applicationName;
            _noHtml = noHtml;
            _skipDisambig = skipDisambig;
            _noRedirect = noRedirect;
            _jsonPretty = jsonPretty;
        }

        public async Task<InstantAnswer> Query()
        {
            string url = BuildUrl();
            string response = await GetResponse(url);

            return DeserializeObject(response);
        }

        private InstantAnswer DeserializeObject(string response)
        {
            return _format == ResponseFormat.Json 
                ? JsonConvert.DeserializeObject<InstantAnswer>(response, new InstantAnswerTypeConverter()) 
                : DeserializeXml<InstantAnswer>(response);
        }

        private static T DeserializeXml<T>(string response)
        {
            var serializer = new XmlSerializer(typeof(T));
            var bytes = Encoding.UTF8.GetBytes(response);
            using (var reader = new MemoryStream(bytes))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        private async Task<string> GetResponse(string url)
        {
            Stream responseStream;
            if (_noHtml)
            {
                WebRequest request = WebRequest.CreateHttp(url);
                WebResponse response = await request.GetResponseAsync();
                responseStream = response.GetResponseStream();
            }
            else
            {
                HttpWebRequest request = WebRequest.CreateHttp(url);
                var response = (HttpWebResponse) await request.GetResponseAsync();
                responseStream = response.GetResponseStream();
            }

            var reader = new StreamReader(responseStream ?? throw new InvalidOperationException());
            return await reader.ReadToEndAsync();
        }

        private string BuildUrl()
        {
            NameValueCollection queryBuilder = HttpUtility.ParseQueryString("https://api.duckduckgo.com/?");
            queryBuilder["q"] = _query;
            queryBuilder["format"] = _format.ToString().ToLower();
            queryBuilder["t"] = _applicationName;
            queryBuilder["no_redirect"] = (_noRedirect ? 1 : 0).ToString();
            queryBuilder["no_html"] = (_noHtml ? 1 : 0).ToString();
            queryBuilder["skip_disambig"] = (_skipDisambig ? 1 : 0).ToString();
            queryBuilder["pretty"] = _jsonPretty.ToString();

            return HttpUtility.UrlDecode(queryBuilder.ToString().Remove(0, 1));
        }
    }
}