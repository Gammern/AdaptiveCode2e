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

            // iSuperCopy = iSub; // base = child 
            iSubCopy = iSuper;    // child = base, relationship reversed

            // iSuper don't rely on SubType.Method3
            iSuper.MethodWhichAcceptsT(aSubType);
            iSuper.MethodWhichAcceptsT(aSuperType); // 

            // iSub rely on SubType.Method3
            iSub.MethodWhichAcceptsT(aSubType);
            try
            {
                iSub.MethodWhichAcceptsT((SubType)aSuperType); // SyperType dont have Method3()
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
