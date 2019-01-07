using PicoBeer.Domain;
using PicoBeer.Services;

namespace PicoBeer.Web.Controllers
{
    public class MaltController : BaseController<Malt>
    {
        public MaltController(IMaltService service) : base(service)
        {
        }
    }
}