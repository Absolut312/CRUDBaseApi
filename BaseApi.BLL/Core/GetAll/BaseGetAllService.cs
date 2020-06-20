using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApi.PAL.Core.GetAll;

namespace BaseApi.BLL.Core.GetAll
{
    public class BaseGetAllService<TEntity>: IBaseGetAllService<TEntity>
    {
        private readonly IBaseGetAllRepository<TEntity> _baseGetAllRepository;

        public BaseGetAllService(IBaseGetAllRepository<TEntity> baseGetAllRepository)
        {
            _baseGetAllRepository = baseGetAllRepository;
        }

        public List<TEntity> GetAll()
        {
            return _baseGetAllRepository.GetAll();
        }
    }
}