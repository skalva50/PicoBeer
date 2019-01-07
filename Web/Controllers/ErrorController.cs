using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PicoBeer.Web
{
    [Route("[controller]/[action]")]
    public class ErrorController : Controller
    {
        [HttpGet]
        [HttpPost]
        public ViewResult Error(string error) 
        {  
            ErrorViewModel errorVM = new ErrorViewModel();
            errorVM.RequestId = error;   
            return View(errorVM);
        }
    }
}