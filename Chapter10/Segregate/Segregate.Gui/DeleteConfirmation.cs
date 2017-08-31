using Segregate.Common;

namespace Segregate.Gui
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decoratedDelete;
        private readonly IUserInteraction userInteraction;

        public DeleteConfirmation(IDelete<TEntity> decoratedDelete, IUserInteraction userInteraction)
        {
            this.decoratedDelete = decoratedDelete;
            this.userInteraction = userInteraction;
        }

        public void Delete(TEntity entity)
        {
            if (userInteraction.Confirm("Are you shure you wnt to delete this entity?"))
            {
                decoratedDelete.Delete(entity);
            }
        }
    }
}
