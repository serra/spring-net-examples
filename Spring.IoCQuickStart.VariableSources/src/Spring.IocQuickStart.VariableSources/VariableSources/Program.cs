using System;
using System.Collections.Generic;
using Example;
using Microsoft.Win32;
using Spring.Context.Support;

namespace Spring.IocQuickStart.VariableSources
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SetUp();

            try
            {
                var ctx = new XmlApplicationContext(@".\VariableSources\objects.xml");
                
                ListPeople(ctx);

                ListSpecials(ctx);
            }
            finally
            {
                TearDown();
            }

            Console.WriteLine("Done ...");
            Console.ReadLine();
        }

        private static void ListPeople(XmlApplicationContext ctx)
        {
            Console.WriteLine("People");
            Console.WriteLine("------");

            var people = (List<Person>) ctx["people"];
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        private static void ListSpecials(XmlApplicationContext ctx)
        {
            Console.WriteLine("Specials");
            Console.WriteLine("--------");
            
            var specials = (Specials)ctx["specials"];

            Console.WriteLine("{0}: {1}", "connection:    ", specials.ConnectionString);
            Console.WriteLine("{0}: {1}", "provider:      ", specials.ProviderName);
            Console.WriteLine("{0}: {1}", "desktop:       ", specials.SpecialFolder1);
            Console.WriteLine("{0}: {1}", "program files: ", specials.SpecialFolder2);
            Console.WriteLine();
        }



        #region support

        private static RegistryKey _key;

        private static void SetUp()
        {
            AddFreddyToRegistry();

            AddKenToEnvironment();
        }

        private static void AddKenToEnvironment()
        {
            // This associates the environment variable with the current process,
            // so it is safe to add and will not mess up any user or machine settings.
            Environment.SetEnvironmentVariable("ken_name", "Ken Cosgrove");
            Environment.SetEnvironmentVariable("ken_age", "32");
        }

        private static void AddFreddyToRegistry()
        {
            _key = Registry.CurrentUser.CreateSubKey("SpringIocQuickStartVariableSources");
            _key.SetValue("freddy_name", "Freddy Rumsen");
            _key.SetValue("freddy_age", 44, RegistryValueKind.DWord);
            _key.Flush();
        }

        private static void TearDown()
        {
            RemoveFreddyFromRegistry();

            RemoveKenFromEnvironment();
        }

        private static void RemoveKenFromEnvironment()
        {
            Environment.SetEnvironmentVariable("ken_name", null);
            Environment.SetEnvironmentVariable("ken_age", null);
        }

        private static void RemoveFreddyFromRegistry()
        {
            Registry.CurrentUser.DeleteSubKey("SpringIocQuickStartVariableSources");
        }

        #endregion
    }
}
