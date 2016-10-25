using Microsoft.AspNetCore.Mvc;

namespace Afs.Diego.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Single Page Application
            return View();
        }
    }
}
