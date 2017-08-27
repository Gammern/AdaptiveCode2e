using System;

namespace SimpleContravariance
{
    public class SubContravariant : IContravariant<SubType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">Will only accept SubType containing Function3()</param>
        public void MethodWhichAcceptsT(SubType parameter)
        {
            Console.WriteLine($"{this.GetType().Name}.MethodWitchAcceptsT({parameter.GetType().Name}) Method3() = {parameter.Method3()}");
        }
    }

    public class SuperContravariant : IContravariant<SuperType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">Accept SuperType and SubType</param>
        public void MethodWhichAcceptsT(SuperType parameter)
        {
            Console.WriteLine($"{this.GetType().Name}.MethodWitchAcceptsT({parameter.GetType().Name}) Method3() don't exist");
        }
    }
}
