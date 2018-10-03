using System.Xml.Serialization;

namespace DuckSharp.Models
{
    public enum InstantAnswerType
    {
        [XmlEnum("A")]
        Article,
        [XmlEnum("D")]
        Disambiguation,
        [XmlEnum("C")]
        Category,
        [XmlEnum("N")]
        Name,
        [XmlEnum("E")]
        Exclusive,
        None
    }
}