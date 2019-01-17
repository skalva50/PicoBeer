using System.Threading.Tasks;
using PicoBeer.Domain;

namespace PicoBeer.Services
{
    public interface IRecipeService : IService<Recipe>
    {
        Task<Recipe> GetByIdWithGraphAsync(int id);
    }
}