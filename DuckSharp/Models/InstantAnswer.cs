using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace DuckSharp.Models
{
    public class InstantAnswer
    {
        [JsonProperty("RelatedTopics")]
        internal RelatedTopics[] InternalRelatedTopics { get; set; }
        
        /// <summary>
        /// Instant Answer response category
        /// </summary>
        public InstantAnswerType Type { get; set; }

        /// <summary>
        /// Topic summary (can contain HTML)
        /// </summary>
        public string Abstract { get; set; }
        /// <summary>
        /// Topic summary (no HTML)
        /// </summary>
        /// <seealso cref="Abstract"/>
        public string AbstractText { get; set; }
        /// <summary>
        /// Name of Abstract source
        /// </summary>
        /// <seealso cref="Abstract"/>
        public string AbstractSource { get; set; }
        
        /// <summary>
        /// Deep link to expand topic page in AbstractSource
        /// </summary>
        /// <seealso cref="AbstractSource"/>
        [JsonProperty("AbstractURL")]
        public string AbstractUrl { get; set; }

        /// <summary>
        /// URL of the image associated with Abstract
        /// </summary>
        /// <seealso cref="Abstract"/>
        [JsonProperty("Image")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Name of topic associated with Abstract
        /// </summary>
        /// <seealso cref="Abstract"/>
        public string Heading { get; set; }

        /// <summary>
        /// Instant answer
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// Instant answer type
        /// </summary>
        /// <seealso cref="Answer"/>
        public string AnswerType { get; set; }

        /// <summary>
        /// Dictionary definition
        /// </summary>
        public string Definition { get; set; }
        /// <summary>
        /// Name of Definition source
        /// </summary>
        /// <seealso cref="Definition" />
        public string DefinitionSource { get; set; }
        
        /// <summary>
        /// Deep link to expand definition page in DefinitionSource
        /// </summary>
        /// <seealso cref="DefinitionSource"/>
        [JsonProperty("DefinitionUrl")]
        public string DefinitionUrl { get; set; }

        public string Entity { get; set; }

        /// <summary>
        /// Array of external sources associated with Abstract
        /// </summary>
        /// <seealso cref="Abstract" />
        public Topic[] Results { get; set; }
        
        /// <summary>
        /// Related topics related to the query
        /// </summary>
        [JsonIgnore]
        public Topic[] RelatedTopics => 
            InternalRelatedTopics
                .Where(r => r.Topic != null)
                .Select(r => r.Topic)
                .ToArray();
        
        /// <summary>
        /// Sections of related topics related to the query
        /// </summary>
        /// <seealso cref="RelatedTopics"/>
        [JsonIgnore]
        public RelatedTopicSection[] RelatedTopicSection => 
            InternalRelatedTopics
                .Where(r => r.RelatedTopicSection != null)
                .Select(r => r.RelatedTopicSection)
                .ToArray();
        
        /// <summary>
        /// !bang redirect URL
        /// </summary>
        /// <seealso cref="DuckSharpClient.GetBangRedirectAsync">
        /// Use DuckDuckGoClient.BangAsync(string) for !bang queries
        /// </seealso>
        [JsonProperty("RedirectURL")]
        public string RedirectUrl { get; set; }
    }
}   