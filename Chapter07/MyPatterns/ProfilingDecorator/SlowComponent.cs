using System;
using System.Threading;

namespace ProfilingDecorator
{
    public class SlowComponent : IComponent
    {
        private readonly Random random;

        public SlowComponent()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }

        public void Something()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(random.Next(i) * 10);
            }    
        }
    }
}
