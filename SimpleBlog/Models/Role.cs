using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
    //All properties and methods of a class that maps to nhibernate must be virtual.
    public class Role
    {
//        public virtual int Id { get; set; }
//        public virtual string Username { get; set; }
//        public virtual string Email { get; set; }
//        public virtual string PasswordHash { get; set; }
    }
    
    //Many ways to map to database in NHibernate
    public class RoleMap : ClassMapping<Role>
    {
        public RoleMap()
        {
            Table("roles");

//            Id(user => user.Id, idMapper => idMapper.Generator(Generators.Identity));
//
//            Property(user => user.Username, mapper => mapper.NotNullable(true));
//            Property(user => user.Email, mapper => mapper.NotNullable(true));
//            Property(user => user.PasswordHash, mapper =>
//            {
//                mapper.Column("password_hash");
//                mapper.NotNullable(true);
//            });
        }
    }
}