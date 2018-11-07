using System;
using System.Collections.Generic;
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
        private RelatedTopics _relatedTopics { get; set; }

        public InstantAnswerType Type { get; set; }

        public string Abstract { get; set; }
        public string AbstractText { get; set; }
        public string AbstractSource { get; set; }
        
        [JsonProperty("AbstractURL")]
        [XmlElement("AbstractURL")]
        public string AbstractUrl { get; set; }

        [JsonProperty("Image")]
        [XmlElement("Image")]
        public string ImageUrl { get; set; }

        public string Heading { get; set; }

        public string Answer { get; set; }
        public string AnswerType { get; set; }

        public string Definition { get; set; }
        public string DefinitionSource { get; set; }
        
        [JsonProperty("DefinitionUrl")]
        [XmlElement("DefinitionUrl")]
        public string DefinitionUrl { get; set; }

        public string Entity { get; set; }

        public Topic[] Results { get; set; }
        
        [JsonIgnore]
        [XmlIgnore]
        public Topic[] RelatedTopics => _relatedTopics.Topics;
        
        [JsonIgnore]
        [XmlIgnore]
        public RelatedTopicSection[] RelatedTopicSection => _relatedTopics.RelatedTopicSections;

        [JsonProperty("RedirectURL")]
        [XmlElement("RedirectURL")]
        public string RedirectUrl { get; set; }
    }
}   