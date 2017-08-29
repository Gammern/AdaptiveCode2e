using System;

namespace AdapterPattern
{
    using System.Runtime.CompilerServices;

    class Program
    {
        public static void Log(string senderTypeName, [CallerMemberName]string functionName = "")
        {
            Console.WriteLine($"{senderTypeName}: {functionName} called");
        }

        static void Main(string[] args)
        {
            IExpectedInterface[] adaptedInstances =
            {
                new AdapteeAdapter(),
                new TargetAdapter(new Target())
            };

            foreach (var adaptor in adaptedInstances)
            {
                adaptor.MethodA();
            }
        }
    }
}