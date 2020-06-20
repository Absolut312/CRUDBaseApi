using System.Threading.Tasks;

namespace BaseApi.BLL.Core.FindById
{
    public interface IBaseFindByIdRepository<TEntity>
    {
        TEntity FindById(int id);
    }
}