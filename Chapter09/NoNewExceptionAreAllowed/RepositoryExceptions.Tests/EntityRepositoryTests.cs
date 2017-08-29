using RepositoryExceptions.Model;
using RepositoryExceptions.Persistence;
using System;
using Xunit;

namespace RepositoryExceptions.Tests
{
    public class EntityRepositoryTests
    {
        public static TheoryData<IEntityRepository<Entity>> data => new TheoryData<IEntityRepository<Entity>>
        {
            new EntityRepository(),
            new UserRepository()
        };

        [Theory]
        [MemberData(nameof(data))]
        public void GetByIdThrowsEnityNotFoundException(IEntityRepository<Entity> sut)
        {
            Assert.ThrowsAny<EntityNotFoundException>(() => sut.GetByID(Guid.Empty));
        }
    }
}
