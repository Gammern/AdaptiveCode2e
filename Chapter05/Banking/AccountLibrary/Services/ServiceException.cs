namespace AccountLibrary.Services
{
    public class ServiceException : AccountLibraryException
    {
        public ServiceException(string message, AccountLibraryException accountLibraryException) 
            : base (message, accountLibraryException) 
        {
        }
    }
}
