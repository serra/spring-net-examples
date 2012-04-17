using System;
using System.IO;
using NHibernateMapByCode.Dao;
using NUnit.Framework;
using Spring.Context.Support;

namespace NHibernateMapByCode
{
    internal class Program
    {
        private static XmlApplicationContext _ctx;

        private static void Main(string[] args)
        {
            DeleteDatabase();

            _ctx = new XmlApplicationContext("objects.xml");
            try
            {
                PrintUsers();

                InsertUser("Marijn");

                PrintUsers();
                
                InsertUser("Iris");

                PrintUsers();

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Any key to exit ...");
            Console.ReadLine();
        }

        private static void DeleteDatabase()
        {
            string db = "users.db";
            if(File.Exists(db))
                File.Delete(db);
        }

        private static void InsertUser(string userName)
        {
            Console.WriteLine("Inserting {0} ... ", userName);
            var c = (CreateUserCommand) _ctx["createUserCommand"];
            c.Name = userName;
            c.Execute();
        }

        private static void PrintUsers()
        {
            var q = (AllUsersQuery) _ctx["allUserQuery"];
            var users = q.GetAll();
            Console.WriteLine("\nThere are {0} users: ", users.Count);
            foreach (var usr in q.GetAll())
            {
                Console.WriteLine(usr);
            }
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Main()
        {
            var ctx = new XmlApplicationContext("objects.xml");
            var o = ctx.GetObject("MyObject");
            Console.WriteLine(o);
        }
    }

    public class MyClass
    {
    }
}