using System;
using System.Diagnostics;

namespace ProfilingDecorator
{
    internal class ProfilingComponent : IComponent
    {
        private readonly IComponent decoratedComponent;
        private readonly Action<string> Log;
        private readonly Stopwatch stopwatch;

        public ProfilingComponent(IComponent comp, Action<string> logAction)
        {
            this.decoratedComponent = comp;
            this.Log = logAction;
            stopwatch = new Stopwatch();
        }

        public void Something()
        {
            stopwatch.Start();
            decoratedComponent.Something();
            stopwatch.Stop();
            Log($"The method took {stopwatch.ElapsedMilliseconds}ms to complete");
        }
    }
}