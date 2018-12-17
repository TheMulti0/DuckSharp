using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DuckSharp.Tests
{
    [TestClass]
    public class DuckSharpTests
    {
        private readonly DuckSharpClient _client = new DuckSharpClient();

        [TestMethod]
        public void TestDisambiguation()
        {
            var result = _client.GetInstantAnswerAsync("apple").Result;
            if (result.RelatedTopicSection == null || result.RelatedTopics == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestHebrew()
        {
            var result = _client.GetInstantAnswerAsync("ωμεν").Result;
            if (result == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFiglet()
        {
            var result = _client.GetInstantAnswerAsync("figlet hi").Result;
            const string answer = " _     _ \n| |__ (_)\n| &#x27;_ &#92;| |\n| | | | |\n|_| |_|_|\n         \n";
            if (result.AnswerType.ToLower() != "figlet" ||
                !string.Equals(result.Answer, answer, StringComparison.CurrentCultureIgnoreCase))
            {
                Assert.Fail();
            }
        }
    }
}
