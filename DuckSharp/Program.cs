using System;
using System.Threading.Tasks;
using DuckSharp.Models;

namespace DuckSharp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            InstantAnswer instantAnswer = await new DuckDuckGoClient().Query("DuckDuckGo");
            Console.WriteLine(instantAnswer.Answer);
            Console.ReadLine();
        }
    }
}