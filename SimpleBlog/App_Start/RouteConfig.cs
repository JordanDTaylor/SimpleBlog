using System.Web.Mvc;
using System.Web.Routing;
using SimpleBlog.Controllers;

namespace SimpleBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces = new[] {typeof (PostsController).Namespace};
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Login", "login", new {controller = "Auth", action = "Login"}, namespaces);

            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" }, namespaces);

            //empty route "" means the one that shows up when nothing is specified
            routes.MapRoute("Home", "", new { controller = "Posts", action = "index" }, namespaces);

        }
    }
}
