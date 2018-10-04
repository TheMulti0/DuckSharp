using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        private readonly ResponseFormat _format;
        private readonly string _applicationName;
        private readonly bool _allowHtml;
        private readonly bool _allowDisambig;
        private readonly bool _allowRedirect;
        private readonly int _jsonPretty;

        private CancellationToken _cancellationToken;
        private HttpClient _client;

        public DuckDuckGoClient(
            ResponseFormat format = ResponseFormat.Json,
            string applicationName = "DuckSharp",
            bool allowHtml = true,
            bool allowDisambig = true,
            bool allowRedirect = true,
            int jsonPretty = 1,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _format = format;
            _applicationName = applicationName;
            _allowHtml = allowHtml;
            _allowDisambig = allowDisambig;
            _allowRedirect = allowRedirect;
            _jsonPretty = jsonPretty;
            _cancellationToken = cancellationToken;
        }

        public async Task<InstantAnswer> QueryAsync(string query)
        {
            string url = BuildUrl(query);
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
            using (var reader = new StringReader(response))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        private async Task<string> GetResponse(string url)
        {
            _client = _client ?? new HttpClient();
            HttpResponseMessage httpResponseMessage = await _client.GetAsync(new Uri(url), _cancellationToken);
            _cancellationToken.ThrowIfCancellationRequested();;
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        private string BuildUrl(string query)
        {
            NameValueCollection queryBuilder = HttpUtility.ParseQueryString("https://api.duckduckgo.com/?");
            queryBuilder["q"] = query;
            queryBuilder["format"] = _format.ToString().ToLower();
            queryBuilder["t"] = _applicationName;
            queryBuilder["no_redirect"] = (!_allowRedirect ? 1 : 0).ToString();
            queryBuilder["no_html"] = (!_allowHtml ? 1 : 0).ToString();
            queryBuilder["skip_disambig"] = (!_allowDisambig ? 1 : 0).ToString();
            queryBuilder["pretty"] = _jsonPretty.ToString();

            return HttpUtility.UrlDecode(queryBuilder.ToString().Remove(0, 1));
        }
    }
}