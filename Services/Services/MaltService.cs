using PicoBeer.Dal;
using PicoBeer.Domain;

namespace PicoBeer.Services
{
    public class MaltService : BaseService<Malt>, IMaltService
    {
        public MaltService(IRepository<Malt> repository, IAsyncRepository<Malt> repositoryAsync) : base(repository, repositoryAsync)
        {
        }
    }
}