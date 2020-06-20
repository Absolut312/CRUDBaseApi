namespace BaseApi.DAL.Core
{
    public interface IToEntityTransformer<TEntity, TDbEntity>
    {
        TEntity ToEntity(TDbEntity dbEntity);
    }
}