using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;

namespace SimpleBlog
{
    //This is set up to run in the Global.asax
    public class Database
    {
        private const string SessionKey = "SimpleBlog.Database.SessionKey";

        private static ISessionFactory _sessionFactory;

        public static ISession Session => (ISession) HttpContext.Current.Items[SessionKey];

        //Run at application startup
        //Used to configure NHibernate
        public static void Configure()
        {
            var config = new Configuration();

            //configure connection string
            config.Configure();

            //add mappings
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<RoleMap>();
            mapper.AddMapping<PostMap>();
            mapper.AddMapping<TagMap>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            //create session factory
            _sessionFactory = config.BuildSessionFactory();


        }

        //Invoked at the beginning of every request
        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        //Invoked at the end of every request.
        //Can be invoked even if a session is never opened.
        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            session?.Close();//Null propagation// if it's not null, close it.
            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
        
}