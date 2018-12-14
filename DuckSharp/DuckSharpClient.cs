using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DuckSharp.Converters;
using DuckSharp;
using Newtonsoft.Json;

namespace DuckSharp
{
    /// <summary>
    /// DuckDuckGo Disposable Multi-purpose API Client
    /// </summary>
    public class DuckSharpClient
    {
        private readonly bool _allowDisambiguation;
        private readonly bool _allowHtml;
        private readonly string _applicationName;

        protected static HttpClient HttpClient;

        /// <summary>
        /// Constructs a DuckSharpClient with given optional parameters
        /// </summary>
        /// <param name="applicationName">Application name for DuckDuckGo API caller (set to 'DuckSharp' by default)</param>
        /// <param name="allowHtml">Allow HTML in text, e.g. bold and italics</param>
        /// <param name="allowDisambiguation">Allow disambiguation answers</param>
        /// <param name="client">Used for using a custom HttpClient</param>
        public DuckSharpClient(
            string applicationName = "DuckSharp",
            bool allowHtml = true,
            bool allowDisambiguation = true,
            HttpClient client = null)
        {
            _applicationName = applicationName;
            _allowHtml = allowHtml;
            _allowDisambiguation = allowDisambiguation;
            
            HttpClient defaultClient = (HttpClient ?? new HttpClient());
            HttpClient = client ?? defaultClient;
        }

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
                    await GetApiResponse(query, token).ConfigureAwait(false),
                    new InstantAnswerTypeConverter(),
                    new RelatedTopicsConverter());

        /// <summary>
        /// Returns a !bang redirect URL for the given query
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>The task object representing the asynchronous operation</returns>
        public async Task<string> GetBangRedirectAsync(
            string query,
            CancellationToken token = default) =>
                (await GetInstantAnswerAsync(query, token).ConfigureAwait(false)).RedirectUrl;

        private async Task<string> GetApiResponse(
            string query,
            CancellationToken token = default)
        {
            Uri uri = BuildUri(query);
            return await GetResponse(uri, token).ConfigureAwait(false);
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
            using (HttpResponseMessage httpResponse = await HttpClient.GetAsync(uri, token).ConfigureAwait(false))
            {
                return await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}
