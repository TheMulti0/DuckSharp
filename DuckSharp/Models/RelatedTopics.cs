using Newtonsoft.Json;

namespace DuckSharp
{
    [JsonObject("RelatedTopic")]
    internal class RelatedTopics
    {
        public Topic Topic { get; }
        
        public RelatedTopicSection RelatedTopicSection { get; }

        public RelatedTopics(Topic topic)
        {
            Topic = topic;
        }

        public RelatedTopics(RelatedTopicSection relatedTopicSection)
        {
            RelatedTopicSection = relatedTopicSection;
        }
    }
}