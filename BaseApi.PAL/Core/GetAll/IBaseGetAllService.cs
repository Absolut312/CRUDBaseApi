using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.PAL.Core.GetAll
{
    public interface IBaseGetAllService<TEntity>
    {
        List<TEntity> GetAll();
    }
}