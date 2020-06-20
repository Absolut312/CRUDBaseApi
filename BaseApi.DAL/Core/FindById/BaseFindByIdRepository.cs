using System.Linq;
using System.Threading.Tasks;
using BaseApi.BLL.Core.FindById;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.DAL.Core.FindById
{
    public class BaseFindByIdRepository<TContext, TEntity, TDbEntity, TTransformer> : IBaseFindByIdRepository<TEntity> 
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TContext: DbContext
         where TTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
             {
                 private readonly TTransformer _toEntityTransformer;
                 private readonly TContext _dbContext;
         
                 public BaseFindByIdRepository(TContext dbContext)
                 {
                     _dbContext = dbContext;
                     _toEntityTransformer = new TTransformer();
                 }

        public TEntity FindById(int id)
        {
            var table = _dbContext.Set<TDbEntity>();
            var dbEntity = table.SingleOrDefault(e => e.Id == id && !e.IsDeleted);
            return dbEntity == null ? null : _toEntityTransformer.ToEntity(dbEntity);
        }
    }
}