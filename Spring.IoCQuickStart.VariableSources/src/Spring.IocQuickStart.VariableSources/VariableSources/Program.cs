using System;
using System.Collections.Generic;
using Example;
using Spring.Context.Support;

namespace Spring.IocQuickStart.VariableSources
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new XmlApplicationContext(@".\VariableSources\objects.xml");
            var people = (List<Person>) ctx["people"];
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Done ...");
            Console.ReadLine();
        }
    }
}
