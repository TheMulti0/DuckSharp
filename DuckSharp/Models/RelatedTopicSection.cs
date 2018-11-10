using Newtonsoft.Json;

namespace DuckSharp.Models
{
    [JsonObject("RelatedTopicsSection")]
    public class RelatedTopicSection
    {
        public string Name { get; set; }
        
        public Topic[] Topics { get; set; }
    }
}