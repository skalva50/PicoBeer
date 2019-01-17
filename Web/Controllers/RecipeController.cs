using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicoBeer.Domain;
using PicoBeer.Services;

namespace PicoBeer.Web.Controllers
{
    public class RecipeController : BaseController<Recipe>
    {
        private readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService service) : base(service)
        {
            _recipeService = service;
        }
        public async override Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RecipeDetailViewModel recipeDetailVM = new RecipeDetailViewModel();
            recipeDetailVM.recipe = await _recipeService.GetByIdWithGraphAsync(id.Value);
            
            if (recipeDetailVM.recipe == null)
            {
                return NotFound();
            }

            return View(recipeDetailVM);
        }
    }
}