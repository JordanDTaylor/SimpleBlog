using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
    //All properties and methods of a class that maps to nhibernate must be virtual.
    public class User
    {
        private const int WorkFactor = 13;

        /// <summary>
        /// Used to prevent time attack to find if username is already registered.
        /// </summary>
        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", WorkFactor);
        }

        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
    
    //Many ways to map to database in NHibernate
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("users");

            Id(user => user.Id, idMapper => idMapper.Generator(Generators.Identity));

            Property(user => user.Username, mapper => mapper.NotNullable(true));
            Property(user => user.Email, mapper => mapper.NotNullable(true));
            Property(user => user.PasswordHash, mapper =>
            {
                mapper.Column("password_hash");
                mapper.NotNullable(true);

            });
        }
    }
}