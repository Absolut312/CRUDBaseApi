using System.Threading.Tasks;
using BaseApi.BLL.Core.Update;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.Delete;

namespace BaseApi.BLL.Core.Delete
{
    public class BaseDeleteService<TEntity>: IBaseDeleteService<TEntity>
      where TEntity: BaseModel, new()
    {
        private readonly IBaseUpdateRepository<TEntity> _baseUpdateRepository;

        public BaseDeleteService(IBaseUpdateRepository<TEntity> baseUpdateRepository)
        {
            _baseUpdateRepository = baseUpdateRepository;
        }

        public TEntity Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            return _baseUpdateRepository.Update(entity);
        }
    }
}