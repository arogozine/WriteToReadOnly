using NotEvil;
using System;
using System.Linq;
using System.Reflection;

namespace Nuker
{
    class Program
    {
        static void Main(string[] args)
        {
            // DateTime.MaxValue is readonly static

            Console.WriteLine($"DateTime.MaxValue = {DateTime.MaxValue}");

            bool someResult = SomeClass.SomeAction();
            Console.WriteLine(someResult);

            Console.WriteLine($"DateTime.MaxValue = {DateTime.MaxValue}");

            Console.ReadKey();
        }
    }
}