using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DuckSharp.Models;

namespace DuckSharp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //bool ok = File.Exists("XmlSample.xml");
            //var response = DeserializeXml<DuckDuckGoResponse>("XmlSample.xml");

            InstantAnswer instantAnswer = await new DuckSharpClient().GetInstantAnswerAsync("apple");
            Console.WriteLine(instantAnswer.Answer);
            Console.ReadLine();
        }

        //private static T DeserializeXml<T>(string fileName) where T: class
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    using (var stream = File.OpenRead(fileName))
        //    {
        //        return serializer.Deserialize(stream) as T;
        //    }
        //}
    }
}