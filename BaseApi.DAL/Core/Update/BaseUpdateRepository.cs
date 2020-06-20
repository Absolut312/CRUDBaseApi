using System;
using System.Linq;
using System.Threading.Tasks;
using BaseApi.BLL.Core.Update;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.DAL.Core.Update
{
    public class BaseUpdateRepository<TContext, TEntity, TDbEntity, TToEntityTransformer, TToDbEntityTransformer> : IBaseUpdateRepository<TEntity>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TContext: DbContext
        where TToEntityTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
        where TToDbEntityTransformer : IToDbEntityTransformer<TEntity, TDbEntity>, new()
    {
        private readonly TToEntityTransformer _toEntityTransformer;
        private readonly TToDbEntityTransformer _toDbEntityTransformer;
        private readonly TContext _dbContext;

        public BaseUpdateRepository(TContext dbContext)
        {
            _dbContext = dbContext;
            _toEntityTransformer = new TToEntityTransformer();
            _toDbEntityTransformer = new TToDbEntityTransformer();
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            
            var dbEntity = _toDbEntityTransformer.ToDbEntity(entity);
            dbEntity.ModificationTime = DateTime.Now;
            var table = _dbContext.Set<TDbEntity>();
            var existingDbEntity = table.SingleOrDefault(x => x.Id == dbEntity.Id);
            if (existingDbEntity == null)
            {
                return null;
            }
            _dbContext.Update(existingDbEntity);
            _dbContext.Entry(existingDbEntity).CurrentValues.SetValues(dbEntity);
            _dbContext.SaveChanges();
            return _toEntityTransformer.ToEntity(dbEntity);
        }
    }
}