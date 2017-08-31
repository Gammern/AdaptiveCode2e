using Segregate.Common;
using System;

namespace Segregate.Gui
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decoratedDelete;
        
        public DeleteConfirmation(IDelete<TEntity> decoratedDelete)
        {
            this.decoratedDelete = decoratedDelete;
        }

        public void Delete(TEntity entity)
        {
            Console.WriteLine("Are you shure you wnt to delete this entity? [y/N]");
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Y)
            {
                decoratedDelete.Delete(entity);
            }
        }
    }
}
