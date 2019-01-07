using PicoBeer.Domain;
using PicoBeer.Services;

namespace PicoBeer.Web.Controllers
{
    public class RecipeController : BaseController<Recipe>
    {
        public RecipeController(IRecipeService service) : base(service)
        {
        }
    }
}