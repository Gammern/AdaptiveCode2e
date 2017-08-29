using System;

namespace RepositoryExceptions.Persistence
{
    /// <summary>
    /// New exception introduced
    /// </summary>
    public class UserNotFoundException : EntityNotFoundException
    {
        public UserNotFoundException() : base()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
