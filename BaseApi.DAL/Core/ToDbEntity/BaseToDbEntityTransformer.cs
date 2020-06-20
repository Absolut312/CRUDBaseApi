using BaseApi.PAL.Core;

namespace BaseApi.DAL.Core.ToDbEntity
{
    public class BaseToDbEntityTransformer<TEntity, TDbEntity>: IToDbEntityTransformer<TEntity, TDbEntity>
    where TEntity: BaseModel, new()
    where TDbEntity: DbBaseModel, new()
    {
        public virtual TDbEntity ToDbEntity(TEntity entity)
        {
            return new TDbEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreationDate = entity.CreationDate,
                IsDeleted = entity.IsDeleted,
                ModificationTime = entity.ModificationTime
            };
        }
    }
}