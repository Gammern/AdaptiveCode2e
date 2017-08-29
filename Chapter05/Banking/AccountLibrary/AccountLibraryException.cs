using System;

namespace AccountLibrary
{
    public class AccountLibraryException : Exception
    {
        public AccountLibraryException()
        {
        }

        public AccountLibraryException(string message, AccountLibraryException accountLibraryException)
            : base(message, accountLibraryException)
        {
        }
    }
}
