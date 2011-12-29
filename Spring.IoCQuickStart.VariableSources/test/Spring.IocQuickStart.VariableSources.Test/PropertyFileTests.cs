using Example;
using NUnit.Framework;
using Spring.Context.Support;

namespace Spring.IocQuickStart.IVariableSource.Test
{
    [TestFixture]
    public class PropertyFileTests
    {
        [Test]
        public void LastFileTakesPrecedence()
        {
            var ctx = new XmlApplicationContext(
                    "assembly://Spring.IocQuickStart.VariableSource.Test/" + 
                    "Spring.IocQuickStart.VariableSource.Test.PropertyFileTestFiles/" +
                    "objects-file-precedence-tests.xml");

            var joan = (Person) ctx["joan"];

            // when using property files, the last loaded file takes precedence (can be considered a bug)
            Assert.AreEqual("2 Joan Harris", joan.Name);
        }

        [Test]
        public void LastEntryTakesPrecedence()
        {
            var ctx = new XmlApplicationContext(
                    "assembly://Spring.IocQuickStart.VariableSource.Test/" +
                    "Spring.IocQuickStart.VariableSource.Test.PropertyFileTestFiles/" +
                    "objects-entry-precedence-tests.xml");
            var joan = (Person)ctx["joan"];

            // when using property files, the last loaded file takes precedence (can be considered a bug)
            Assert.AreEqual("Using last entry Joan Harris", joan.Name);
        }
    }
}