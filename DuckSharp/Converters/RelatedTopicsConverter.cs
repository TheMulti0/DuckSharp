using System;
using DuckSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DuckSharp.Converters
{
    internal class RelatedTopicsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(RelatedTopics);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) 
            => new RelatedTopics();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}