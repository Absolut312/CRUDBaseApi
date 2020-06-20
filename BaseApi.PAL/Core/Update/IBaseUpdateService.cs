using System.Threading.Tasks;

namespace BaseApi.PAL.Core.Update
{
    public interface IBaseUpdateService<TEntity>
    {
        TEntity Update(TEntity entity);
    }
}