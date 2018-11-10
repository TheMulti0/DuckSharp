using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DuckSharp.Converters;
using DuckSharp.Models;
using Newtonsoft.Json;

namespace DuckSharp
{
    /// <inheritdoc />
    /// <summary>
    /// DuckDuckGo Disposable Multi-purpose API Client
    /// </summary>
    public class DuckSharpClient : IDisposable
    {
        private readonly bool _allowDisambiguation;
        private readonly bool _allowHtml;
        private readonly string _applicationName;

        private HttpClient _client;

        /// <summary>
        /// Constructs a DuckSharpClient with given optional parameters
        /// </summary>
        /// <param name="applicationName">Application name for DuckDuckGo API caller (set to 'DuckSharp' by default)</param>
        /// <param name="allowHtml">Allow HTML in text, e.g. bold and italics</param>
        /// <param name="allowDisambiguation">Allow disambiguation answers</param>
        public DuckSharpClient(
            string applicationName = "DuckSharp",
            bool allowHtml = true,
            bool allowDisambiguation = true)
        {
            _applicationName = applicationName;
            _allowHtml = allowHtml;
            _allowDisambiguation = allowDisambiguation;
        }

        public void Dispose() 
            => _client?.Dispose();

        /// <summary>
        /// Returns an instant answer from DuckDuckGo API with the given query
        /// </summary>
        /// <param name="query">Search query</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The task object representing the asynchronous operation</returns>
        public async Task<InstantAnswer> GetInstantAnswerAsync(
            string query,
            CancellationToken token = default) => 
                JsonConvert.DeserializeObject<InstantAnswer>(
                    await GetApiResponse(query, token: token),
                    new InstantAnswerTypeConverter(),
                    new RelatedTopicsConverter());

        /// <summary>
        /// Returns a !bang redirect URL for the given query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="token"></param>
        /// <returns>The task object representing the asynchronous operation</returns>
        public async Task<string> GetBangRedirectAsync(
            string query,
            CancellationToken token = default) =>
                (await GetInstantAnswerAsync(query, token)).RedirectUrl;

        private async Task<string> GetApiResponse(
            string query,
            CancellationToken token = default)
        {
            Uri uri = BuildUri(query);
            return await GetResponse(uri, token);
        }

        private Uri BuildUri(string query)
        {
            var parameters = new Dictionary<string, string>
            {
                ["q"] = query,
                ["q"] = query,
                ["format"] = "json",
                ["t"] = _applicationName,
                ["no_redirect"] = 1.ToString(),
                ["no_html"] = (!_allowHtml ? 1 : 0).ToString(),
                ["skip_disambig"] = (!_allowDisambiguation ? 1 : 0).ToString(),
                ["pretty"] = 1.ToString()
            };

            var queryBuilder = new StringBuilder();
            foreach (var pair in parameters)
            {
                queryBuilder.AppendFormat(
                    CultureInfo.InvariantCulture, "{0}={1}&", pair.Key, pair.Value);
            }

            var builder = new UriBuilder("https://api.duckduckgo.com")
            {
                Query = queryBuilder.ToString()
            };
            return builder.Uri;
        }

        private async Task<string> GetResponse(Uri uri, CancellationToken token)
        {
            _client = _client ?? new HttpClient();
            using (HttpResponseMessage httpResponse = await _client.GetAsync(uri, token))
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}