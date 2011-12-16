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
                ListPepoleFromContext();
            }
            finally
            {
                TearDown();
            }

            Console.WriteLine("Done ...");
            Console.ReadLine();
        }

        private static void ListPepoleFromContext()
        {
            var ctx = new XmlApplicationContext(@".\VariableSources\objects.xml");
            var people = (List<Person>) ctx["people"];
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
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
