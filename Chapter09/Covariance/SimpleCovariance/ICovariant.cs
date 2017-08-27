namespace SimpleCovariance
{
    public interface ICovariant<out T> where T:SuperType, new()
    {
        T MethodWhichReturnsT();
    }
}
