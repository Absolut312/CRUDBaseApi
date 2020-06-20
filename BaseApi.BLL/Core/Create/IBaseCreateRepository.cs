using System.Threading.Tasks;

namespace BaseApi.BLL.Core.Create
{
    public interface IBaseCreateRepository<TEntity>
    {
        TEntity Create(TEntity entity);
    }
}