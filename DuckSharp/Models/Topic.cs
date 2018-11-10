using Newtonsoft.Json;

namespace DuckSharp.Models
{
    [JsonObject("RelatedTopic")]
    public class Topic
    {
        [JsonProperty("Result")]
        public string ResultText { get; set; }

        [JsonProperty("FirstURL")]
        public string FirstUrl { get; set; }

        public Icon Icon { get; set; }

        public string Text { get; set; }
    }
}