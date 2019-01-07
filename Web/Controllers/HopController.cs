using PicoBeer.Domain;
using PicoBeer.Services;

namespace PicoBeer.Web.Controllers
{
    public class HopController : BaseController<Hop>
    {
        public HopController(IHopService service) : base(service)
        {
        }
    }
}