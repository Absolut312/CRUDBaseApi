using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.BLL.Core.GetAll
{
    public interface IBaseGetAllRepository<TEntity>
    {
        List<TEntity> GetAll();
    }
}