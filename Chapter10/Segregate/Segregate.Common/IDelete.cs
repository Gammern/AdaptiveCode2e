namespace Segregate.Common
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
