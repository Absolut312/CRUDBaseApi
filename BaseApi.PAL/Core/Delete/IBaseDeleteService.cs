using System.Threading.Tasks;

namespace BaseApi.PAL.Core.Delete
{
    public interface IBaseDeleteService<TEntity>
    {
        TEntity Delete(TEntity entity);
    }
}