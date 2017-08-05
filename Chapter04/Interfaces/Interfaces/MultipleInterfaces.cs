namespace Interfaces
{
    public interface IInterfaceOne
    {
        void MethodOne();
    }

    public interface IInterfaceTwo
    {
        void MethodTwo();
    }

    class ImplementingMultipleInterfaces : IInterfaceOne, IInterfaceTwo
    {
        public void MethodOne()
        {
        }

        public void MethodTwo()
        {
        }
    }
}
