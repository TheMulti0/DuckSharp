using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DuckSharp.Converters
{
    internal class RelatedTopicsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(RelatedTopics);

        public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            return jObject
                .Properties()
                .Any(p => p.Name == "Result")
                ? new RelatedTopics(jObject.ToObject<Topic>())
                : new RelatedTopics(jObject.ToObject<RelatedTopicSection>());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}