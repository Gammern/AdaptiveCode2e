using System;

namespace Interfaces
{
    public class SimpleInterfaceImplementation : ISimpleInteface
    {
        public string ThisStringPropertyNeedsImplementingToo { get; set; } = "mydefault";

        private int encapsulatedInteger = 0;
        public int ThisIntegerPropertyOnlyNeedsGetter { get => encapsulatedInteger; set => encapsulatedInteger = value; }

        public event EventHandler<EventArgs> InterfacesCanContainEventsToo = delegate { };

        public void ThisMethodRequiresImplementation()
        {
            InterfacesCanContainEventsToo(this, EventArgs.Empty);
        }
    }
}
