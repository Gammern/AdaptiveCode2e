using System;

namespace SubtypeCovariance
{
    using Model;
    using Persitence;

    class Program
    {
        static void Main(string[] args)
        {
            IEntityRepository<Entity> repo = new UserRepository();
            var entity = repo.GetByID(Guid.Empty);
            Console.WriteLine(entity.ToString() + " should be User");
            repo = new EntityRepository();
            entity = repo.GetByID(Guid.Empty);
            Console.WriteLine(entity.ToString() + " should be Entity");
        }
    }
}
