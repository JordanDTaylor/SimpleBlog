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

            routes.MapRoute("TagForRealThisTime", "tag/{idAndSlug}", new { controller = "Posts", action = "Tag" },
               namespaces);
            routes.MapRoute("Tag", "tag/{id}-{slug}", new { controller = "Posts", action = "Tag" }, namespaces);

            routes.MapRoute("PostForRealThisTime", "post/{idAndSlug}", new {controller = "Posts", action = "Show"},
                namespaces);
            routes.MapRoute("Post", "post/{id}-{slug}", new { controller = "Posts", action = "Show" }, namespaces);

            routes.MapRoute("Login", "login", new {controller = "Auth", action = "Login"}, namespaces);

            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" }, namespaces);

            //empty route "" means the one that shows up when nothing is specified
            routes.MapRoute("Home", "", new { controller = "Posts", action = "index" }, namespaces);

            routes.MapRoute("Sidebar", "", new { controller = "Layout", action = "Sidebar" }, namespaces);

            routes.MapRoute("Error500", "errors/500", new {controller="Errors", action="Error"}, namespaces);
            routes.MapRoute("Error404", "errors/404", new {controller="Errors", action="NotFound"}, namespaces);
        }
    }
}
