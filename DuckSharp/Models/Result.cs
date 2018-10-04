using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DuckSharp.Models
{
    public class Result
    {
        [JsonProperty("Result")]
        [XmlElement("Result")]
        public string ResultText { get; set; }

        [JsonProperty("FirstURL")]
        [XmlElement("FirstURL")]
        public string FirstUrl { get; set; }

        public Icon Icon { get; set; }

        public string Text { get; set; }
    }
}