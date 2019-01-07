using PicoBeer.Domain;
using PicoBeer.Dal;
namespace PicoBeer.Services
{
    public class RecipeService : BaseService<Recipe>, IRecipeService
    {
        public RecipeService(IRepository<Recipe> repository, IAsyncRepository<Recipe> repositoryAsync) : base(repository, repositoryAsync)
        {
        }
    }
}