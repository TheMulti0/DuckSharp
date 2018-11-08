using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DuckSharp.Models
{
    [Serializable]
    [XmlRoot("DuckDuckGoResponse")]
    public class InstantAnswer
    {
        [JsonProperty("RelatedTopics")]
        [XmlElement("RelatedTopics")]
        internal RelatedTopics _relatedTopics { get; set; }
        
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
        [XmlElement("AbstractURL")]
        public string AbstractUrl { get; set; }

        /// <summary>
        /// URL of the image associated with Abstract
        /// </summary>
        /// <seealso cref="Abstract"/>
        [JsonProperty("Image")]
        [XmlElement("Image")]
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
        [XmlElement("DefinitionUrl")]
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
        [XmlIgnore]
        public Topic[] RelatedTopics => _relatedTopics.Topics;
        
        /// <summary>
        /// Sections of related topics related to the query
        /// </summary>
        /// <seealso cref="RelatedTopics"/>
        [JsonIgnore]
        [XmlIgnore]
        public RelatedTopicSection[] RelatedTopicSection => _relatedTopics.RelatedTopicSections;

        /// <summary>
        /// !bang redirect URL
        /// </summary>
        /// <seealso cref="DuckSharpClient.BangAsync(string, CancellationToken)">
        /// Use DuckDuckGoClient.BangAsync(string) for !bang queries
        /// </seealso>
        [JsonProperty("RedirectURL")]
        [XmlElement("RedirectURL")]
        public string RedirectUrl { get; set; }
    }
}   