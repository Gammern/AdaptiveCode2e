using System;

namespace AdapterPattern
{
    using System.Runtime.CompilerServices;

    class Program
    {
        public static void Log(object sender, [CallerMemberName]string functionName = "")
        {
            Console.WriteLine($"{sender.GetType().FullName}: {functionName} called");
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