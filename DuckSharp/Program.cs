using System;
using DuckSharp.Models;

namespace DuckSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InstantAnswer instantAnswer = new DuckDuckGoClient("DuckDuckGo", ResponseFormat.Xml).Query().Result;
            Console.WriteLine(instantAnswer.Answer);
            Console.ReadLine();
        }
    }
}