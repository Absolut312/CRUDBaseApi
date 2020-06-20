using System.Threading.Tasks;
using BaseApi.PAL.Core.FindById;

namespace BaseApi.BLL.Core.FindById
{
    public class BaseFindByIdService<TEntity> : IBaseFindByIdService<TEntity>
    {
        private readonly IBaseFindByIdRepository<TEntity> _baseFindByIdRepository;

        public BaseFindByIdService(IBaseFindByIdRepository<TEntity> baseFindByIdRepository)
        {
            _baseFindByIdRepository = baseFindByIdRepository;
        }

        public TEntity FindById(int id)
        {
            return _baseFindByIdRepository.FindById(id);
        }
    }
}