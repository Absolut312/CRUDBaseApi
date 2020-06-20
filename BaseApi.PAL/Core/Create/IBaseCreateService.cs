using System.Threading.Tasks;

namespace BaseApi.PAL.Core.Create
{
    public interface IBaseCreateService<TEntity>
    {
        TEntity Create(TEntity entity);
    }
}