using System.Threading.Tasks;

namespace BaseApi.BLL.Core.Update
{
    public interface IBaseUpdateRepository<TEntity>
    {
        TEntity Update(TEntity entity);
    }
}