namespace Segregate.Common
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
