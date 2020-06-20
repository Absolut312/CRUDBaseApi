namespace BaseApi.DAL.Core
{
    public interface IToDbEntityTransformer<TEntity, TDbEntity>
    {
        TDbEntity ToDbEntity(TEntity entity);
    }
}