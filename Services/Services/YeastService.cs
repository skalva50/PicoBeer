using PicoBeer.Dal;
using PicoBeer.Domain;

namespace PicoBeer.Services
{
    public class YeastService : BaseService<Yeast>, IYeastService
    {
        public YeastService(IRepository<Yeast> repository, IAsyncRepository<Yeast> repositoryAsync) : base(repository, repositoryAsync)
        {
        }
    }
}