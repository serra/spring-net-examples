using System;
using NHibernate;

namespace NHibernateMapByCode.Dao
{
    public class CreateUserCommand
    {
        public ISessionFactory SessionFactory { get; set; }

        public string Name { get; set; }
        
        public void Execute()
        {
            using(var s = SessionFactory.OpenSession())
            {
                var newUser = new User() {Id = Guid.NewGuid(), Name = Name}; 
                s.Save(newUser);
                s.Flush();
            }
        }
    }
}