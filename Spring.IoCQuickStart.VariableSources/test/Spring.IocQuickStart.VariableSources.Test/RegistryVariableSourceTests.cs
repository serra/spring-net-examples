using System;
using Example;
using Microsoft.Win32;
using NUnit.Framework;
using Spring.Context.Support;
using System.Linq;
using Spring.Objects.Factory;

namespace Spring.IocQuickStart.IVariableSource.Test
{
    [TestFixture]
    public class RegistryVariableSourceTests
    {
        private static RegistryKey _key;
        private static string _subkey = "TestKeyForVariableSourcesTests";

        [SetUp]
        public void SetUp()
        {
            AddFreddyToRegistry();
        }

        [TearDown]
        public void TearDown()
        {
            RemoveFreddyFromRegistry();
        }

        [Test]
        public void ReadFromRegistryTest()
        {
            var ctx = new XmlApplicationContext(
                    "assembly://Spring.IocQuickStart.VariableSource.Test/" +
                    "Spring.IocQuickStart.VariableSource.Test.PropertyFileTestFiles/" +
                    "objects-correctregistrykey.xml");
            var freddy = (Person)ctx["freddy"];

            Assert.AreEqual("Freddy Rumsen", freddy.Name);
        }

        [Test]
        public void NonExistingKeyThrows()
        {
            Assert.False(Registry.CurrentUser.GetSubKeyNames().Contains("TestKeyDoesNotExist"));

            try
            {
                var ctx = new XmlApplicationContext(
                    "assembly://Spring.IocQuickStart.VariableSource.Test/" +
                    "Spring.IocQuickStart.VariableSource.Test.PropertyFileTestFiles/" +
                    "objects-nonexistingregistrykey.xml");
            }
            catch (ObjectCreationException oe)
            {
                Assert.Pass();
            }

        }


        private static void AddFreddyToRegistry()
        {
            _key = Registry.CurrentUser.CreateSubKey(_subkey);
            _key.SetValue("freddy_name", "Freddy Rumsen");
            _key.SetValue("freddy_age", 44, RegistryValueKind.DWord);
            _key.Flush();
        }

        private static void RemoveFreddyFromRegistry()
        {
            Registry.CurrentUser.DeleteSubKey(_subkey);
        }
    }
}
