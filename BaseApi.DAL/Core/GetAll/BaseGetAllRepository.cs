using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseApi.BLL.Core.GetAll;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.DAL.Core.GetAll
{
    public class BaseGetAllRepository<TContext, TEntity, TDbEntity, TTransformer>: IBaseGetAllRepository<TEntity>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TContext: DbContext
        where TTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
    {
        private readonly TTransformer _toEntityTransformer;
        private readonly TContext _dbContext;

        public BaseGetAllRepository(TContext dbContext)
        {
            _dbContext = dbContext;
            _toEntityTransformer = new TTransformer();
        }
        
        public List<TEntity> GetAll()
        {
            var table = _dbContext.Set<TDbEntity>();
            return table.Where(x => !x.IsDeleted).Select(y => _toEntityTransformer.ToEntity(y)).ToList();
        }
    }
}