using System;
using System.Collections.Generic;
using Example;
using NUnit.Framework;
using Spring.Context.Support;

namespace Spring.IocQuickStart.IVariableSource.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ListPeople()
        {
            // e.g.:
            //var ctx = new XmlApplicationContext(@".\VariableSources\objects.xml");
            //var people = (List<Person>)ctx["people"];
            //foreach (var person in people)
            //{
            //    Console.WriteLine(person);
            //}
        }
    }
}