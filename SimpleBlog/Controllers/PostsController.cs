using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return View( );
        }
    }
}