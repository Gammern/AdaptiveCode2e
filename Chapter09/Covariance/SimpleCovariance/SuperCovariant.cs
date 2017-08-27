namespace SimpleCovariance
{
    public class SuperCovariant : ICovariant<SuperType>
    {
        public SuperType MethodWhichReturnsT() => new SuperType();
    }
}
