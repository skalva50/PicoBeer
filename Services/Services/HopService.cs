using PicoBeer.Dal;
using PicoBeer.Domain;

namespace PicoBeer.Services
{
    public class HopService : BaseService<Hop>, IHopService
    {
        public HopService(IRepository<Hop> repository, IAsyncRepository<Hop> repositoryAsync) : base(repository, repositoryAsync)
        {
        }
    }
}