using System;

namespace AccountLibrary.Services
{
    using Domain;

    public class ServiceException : Exception
    {
        public ServiceException(string message, DomainException domainException) 
            : base (message, domainException) 
        {
        }
    }
}
