using System.Web.Mvc;

namespace RomaBackend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("");
        }
    }
}