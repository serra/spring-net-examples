using NUnit.Framework;
using Spring.Context.Support;
using Spring.IocQuickStart.VariableSource.Test.Properties;

namespace Spring.IocQuickStart.VariableSource.Test
{
    [TestFixture]
    public class Tests
    {
        private Settings _props;

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

        [SetUp]
        public void UserSettingSetup()
        {
            // reset to defaults
            _props = Properties.Settings.Default;
            _props.Reset();
            _props.Save();
        }

        [Test]
        public void CanReadUserSettingsDefault()
        {
            Assert.AreEqual(71, _props.ida_age);
            Assert.AreEqual("Ida Blankenship", _props.ida_name);
        }

        [Test]
        public void CanSaveChangesToUserSettings()
        {
            _props.ida_age = 81;
            _props.Save();
            _props.Reload();
            Assert.AreEqual(81, _props.ida_age);
        }

        [Test]
        public void CanUseDefaultUserSettingsAsVariableSource()
        {
            Assert.AreEqual("Ida Blankenship", _props.ida_name);
            Assert.AreEqual(71, _props.ida_age);

            var ctx = new XmlApplicationContext("assembly://Spring.IocQuickStart.VariableSource.Test/Spring.IocQuickStart.VariableSource.Test/ida.xml");
            var ida = (Example.Person)ctx["ida"];

            Assert.AreEqual(71, ida.Age);
            Assert.AreEqual("Ida Blankenship", ida.Name);
        }

        [Test]
        public void CanUseLocalUserSettingsAsVariableSource()
        {
            Assert.AreEqual("Ida Blankenship", _props.ida_name);
            Assert.AreEqual(71, _props.ida_age);

            _props.ida_age = 81;
            _props.Save();
            _props.Reload();

            Assert.AreEqual(81, _props.ida_age);

            var ctx = new XmlApplicationContext("assembly://Spring.IocQuickStart.VariableSource.Test/Spring.IocQuickStart.VariableSource.Test/ida.xml");
            var ida = (Example.Person)ctx["ida"];

            Assert.AreEqual(81, ida.Age);
        }

        [Test]
        public void CanUseLocalUserSettingsAndSettingsAre_N_O_T_AvailableForPrototypesAfterContainerLoadedSettingsAsVariableSource()
        {
            Assert.AreEqual("Ida Blankenship", _props.ida_name);
            Assert.AreEqual(71, _props.ida_age);

            var ctx = new XmlApplicationContext("assembly://Spring.IocQuickStart.VariableSource.Test/Spring.IocQuickStart.VariableSource.Test/ida.xml");

            AssertPrototype(ctx, "ida");

            var ida = (Example.Person)ctx["ida"];
            Assert.AreEqual(71, ida.Age);

            _props.ida_age = 81;
            _props.Save();
            _props.Reload();

            Assert.AreEqual(81, _props.ida_age);

            ida = (Example.Person)ctx["ida"];
            Assert.AreEqual(71, ida.Age);
        }

        private void AssertPrototype(XmlApplicationContext ctx, string id)
        {
            Assert.IsFalse(ctx.IsSingleton(id), "Object with id '{0}' should be of prototype scope.", id);
        }
    }
}