using BaseApi.PAL.Core;

namespace BaseApi.DAL.Core.ToEntity
{
    public class BaseToEntityTransformer<TEntity, TDbEntity>: IToEntityTransformer<TEntity, TDbEntity>
    where TEntity: BaseModel, new()
    where TDbEntity: DbBaseModel, new()
    {
        public virtual TEntity ToEntity(TDbEntity dbEntity)
        {
            return new TEntity
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name,
                Description = dbEntity.Description,
                CreationDate = dbEntity.CreationDate,
                IsDeleted = dbEntity.IsDeleted,
                ModificationTime = dbEntity.ModificationTime
            };
        }
    }
}