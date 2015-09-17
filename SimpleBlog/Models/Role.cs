using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
    public class Role
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    
    public class RoleMap : ClassMapping<Role>
    {
        public RoleMap()
        {
            Table("roles");

            Id(role => role.Id, idMapper => idMapper.Generator(Generators.Identity));

            Property(role => role.Name, mapper => mapper.NotNullable(true));
        }
    }
}