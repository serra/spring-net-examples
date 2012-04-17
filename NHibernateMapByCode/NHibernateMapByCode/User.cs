using System;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateMapByCode
{
    public class User
    {
        public User()
        {
            Id = Guid.Empty;
        }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Id.ToString().Substring(0, 5));
        }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(u => u.Id);
            Property(u => u.Name, m => m.Unique(true));
        }
    }
}