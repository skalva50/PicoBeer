using PicoBeer.Domain;
using PicoBeer.Services;

namespace PicoBeer.Web.Controllers
{
    public class YeastController : BaseController<Yeast>
    {
        public YeastController(IYeastService service) : base(service)
        {
        }
    }
}