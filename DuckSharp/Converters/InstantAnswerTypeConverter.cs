using System;
using DuckSharp.Models;
using Newtonsoft.Json;

namespace DuckSharp.Converters
{
    internal class InstantAnswerTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(InstantAnswerType);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            switch ((string) reader.Value)
            {
                case "A":
                    return InstantAnswerType.Article;
                case "D":
                    return InstantAnswerType.Disambiguation;
                case "C"
                    : return InstantAnswerType.Category;
                case "N":
                    return InstantAnswerType.Name;
                case "E":
                    return InstantAnswerType.Exclusive;
                default:
                    return InstantAnswerType.None;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}