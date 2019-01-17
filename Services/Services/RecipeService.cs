using PicoBeer.Domain;
using PicoBeer.Dal;
using System.Threading.Tasks;
using System.Linq;

namespace PicoBeer.Services
{
    public class RecipeService : BaseService<Recipe>, IRecipeService
    {
        public RecipeService(IRepository<Recipe> repository, IAsyncRepository<Recipe> repositoryAsync) : base(repository, repositoryAsync)
        {
        }
        public async Task<Recipe> GetByIdWithGraphAsync(int id)
        {
            BaseSpecification<Recipe> spec = new BaseSpecification<Recipe>(O => O.Id == id);
            spec.AddInclude("ListMalt.Ingredient");
            spec.AddInclude("ListHop.Ingredient");
            spec.AddInclude("ListYeast.Ingredient");
            return await _repositoryAsync.GetSingleBySpecAsync(spec);
        }
    }
}