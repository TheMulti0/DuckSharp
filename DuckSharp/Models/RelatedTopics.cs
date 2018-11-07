using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DuckSharp.Models
{
    internal class RelatedTopics
    {
        [JsonProperty("RelatedTopic")]
        [XmlElement("RelatedTopic")]
        public Topic[] Topics { get; set; }
        
        [JsonProperty("RelatedTopicsSection")]
        [XmlElement("RelatedTopicsSection")]
        public RelatedTopicSection[] RelatedTopicSections { get; set; }
    }
}