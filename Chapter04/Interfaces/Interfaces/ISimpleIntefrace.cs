using System;

namespace Interfaces
{
    public interface ISimpleInteface
    {
        void ThisMethodRequiresImplementation();
        string ThisStringPropertyNeedsImplementingToo { get; set; }
        int ThisIntegerPropertyOnlyNeedsGetter { get; }
        event EventHandler<EventArgs> InterfacesCanContainEventsToo;
    }
}
