using Microsoft.AspNetCore.Mvc;

namespace PicoBeer.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}