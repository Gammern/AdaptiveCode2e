namespace SimpleContravariance
{
    public interface IContravariant<in T>
    {
        void MethodWhichAcceptsT(T parameter);
    }
}
