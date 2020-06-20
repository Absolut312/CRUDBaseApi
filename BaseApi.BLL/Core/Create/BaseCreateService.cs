using System.Threading.Tasks;
using BaseApi.PAL.Core.Create;

namespace BaseApi.BLL.Core.Create
{
    public class BaseCreateService<TEntity> : IBaseCreateService<TEntity>
    {
        private readonly IBaseCreateRepository<TEntity> _baseCreateRepository;

        public BaseCreateService(IBaseCreateRepository<TEntity> baseCreateRepository)
        {
            _baseCreateRepository = baseCreateRepository;
        }

        public TEntity Create(TEntity entity)
        {
            return _baseCreateRepository.Create(entity);
        }
    }
}