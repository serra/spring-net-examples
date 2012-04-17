using System.Collections.Generic;
using NHibernate;
using Spring.Transaction.Interceptor;

namespace NHibernateMapByCode.Dao
{
    public class AllUsersQuery
    {
        public ISessionFactory SessionFactory { get; set; }

        public IList<User> GetAll()
        {
            IList<User> users;
            using (var s = SessionFactory.OpenSession())
            {
                users = s.QueryOver<User>().List(); 
            }

            return users;
        }
    }
}