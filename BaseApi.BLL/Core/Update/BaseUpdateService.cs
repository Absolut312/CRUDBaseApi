using System.Threading.Tasks;
using BaseApi.PAL.Core.Update;

namespace BaseApi.BLL.Core.Update
{
    public class BaseUpdateService<TEntity> : IBaseUpdateService<TEntity>
    {
        private readonly IBaseUpdateRepository<TEntity> _baseUpdateRepository;

        public BaseUpdateService(IBaseUpdateRepository<TEntity> baseUpdateRepository)
        {
            _baseUpdateRepository = baseUpdateRepository;
        }

        public TEntity Update(TEntity entity)
        {
            return _baseUpdateRepository.Update(entity);
        }
    }
}