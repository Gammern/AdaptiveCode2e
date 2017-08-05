using System;

namespace Interfaces
{
    public class ExplicitSimpleInterfaceImplementation : ISimpleInteface
    {
        private int encapsulatedInteger;
        private event EventHandler<EventArgs> encapsulatedEvent = delegate { }; // dummy delegate to avoid null check or exception

        public ExplicitSimpleInterfaceImplementation()
        {
            this.encapsulatedInteger = 4;
        }

        void ISimpleInteface.ThisMethodRequiresImplementation()
        {
            encapsulatedEvent(this, EventArgs.Empty);
        }

        string ISimpleInteface.ThisStringPropertyNeedsImplementingToo { get; set; }

        int ISimpleInteface.ThisIntegerPropertyOnlyNeedsGetter => encapsulatedInteger;

        event EventHandler<EventArgs> ISimpleInteface.InterfacesCanContainEventsToo
        {
            add
            {
                    encapsulatedEvent += value;
            }

            remove
            {
                if (value == null) // fake delete all handlers
                {
                    encapsulatedEvent = (s, e) => { Console.WriteLine("Sorry, nothing here. Event has been replaced"); };
                }
                else
                    encapsulatedEvent -= value;
            }
        }
    }
}
