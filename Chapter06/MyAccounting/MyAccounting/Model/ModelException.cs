using System;

namespace MyAccounting.Model
{
    public class ModelException : Exception
    {
        public ModelException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
