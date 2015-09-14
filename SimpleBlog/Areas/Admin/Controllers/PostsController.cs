using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{   
    [Authorize(Roles = "admin")]
    public class PostsController : Controller
    {
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return Content( "ADMIN POSTS!");
        }
    }
}