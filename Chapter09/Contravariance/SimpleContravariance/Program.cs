using System;

namespace SimpleContravariance
{
    class Program
    {
        static SuperType aSuperType = new SuperType();
        static SubType aSubType = new SubType();

        static void Main(string[] args)
        {
            IContravariant<SuperType> iSuperCopy, iSuper = new SuperContravariant();
            IContravariant<SubType> iSubCopy, iSub = new SubContravariant();

            iSubCopy = iSuper;    // child = base, relationship reversed
            // iSuperCopy = iSub; // base = child 

            // iSuper don't rely on SubType.Method3
            iSuper.MethodWhichAcceptsT(aSubType); 
            iSuper.MethodWhichAcceptsT(aSuperType); // 

            // iSub rely on SubType.Method3
            iSub.MethodWhichAcceptsT(aSubType); 
            // iSub.MethodWhichAcceptsT(aSuperType); // SyperType dont have Method3()
        }
    }
}
