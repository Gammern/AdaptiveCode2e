namespace SimpleCovariance
{
    public class SubCovariant : ICovariant<SubType>
    {
        public SubType MethodWhichReturnsT() => new SubType();
    }
}
