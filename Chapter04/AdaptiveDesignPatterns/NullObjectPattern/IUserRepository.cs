using System;

namespace NullObjectPattern
{
    public interface IUserRepository
    {
        IUser GetByID(Guid userID);
    }
}