using System;
using System.Threading.Tasks;
using BaseApi.BLL.Core.Create;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.DAL.Core.Create
{
    public class BaseCreateRepository<TContext, TEntity, TDbEntity, TToEntityTransformer, TToDbEntityTransformer> : IBaseCreateRepository<TEntity>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TContext : DbContext
        where TToEntityTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
        where TToDbEntityTransformer : IToDbEntityTransformer<TEntity, TDbEntity>, new()
    {
        private readonly TToEntityTransformer _toEntityTransformer;
        private readonly TToDbEntityTransformer _toDbEntityTransformer;
        private readonly TContext _dbContext;

        public BaseCreateRepository(TContext dbContext)
        {
            _dbContext = dbContext;
            _toEntityTransformer = new TToEntityTransformer();
            _toDbEntityTransformer = new TToDbEntityTransformer();
        }

        public TEntity Create(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            
            var dbEntity = _toDbEntityTransformer.ToDbEntity(entity);
            dbEntity.CreationDate = DateTime.Now;
            dbEntity.ModificationTime = DateTime.Now;
            var table = _dbContext.Set<TDbEntity>();
            table.Add(dbEntity);
            _dbContext.SaveChanges();
            return _toEntityTransformer.ToEntity(dbEntity);
        }
    }
}