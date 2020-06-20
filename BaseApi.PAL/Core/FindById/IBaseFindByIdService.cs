using System.Threading.Tasks;

namespace BaseApi.PAL.Core.FindById
{
    public interface IBaseFindByIdService<TEntity>
    {
        TEntity FindById(int id);
    }
}