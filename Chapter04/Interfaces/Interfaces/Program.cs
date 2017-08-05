using System;

namespace Interfaces
{
    class Program
    {
        static void EventHandler2(object sender, EventArgs e)
        {
            Console.WriteLine($"{sender.ToString()} got called ");
        }
        
        // alternate version of the above func as a lambda
        static EventHandler<EventArgs> EventHandler = (s, e) => 
        {
            Console.WriteLine($"{s.ToString()} got called ");
        };

        static void Main(string[] args)
        {
            SimpleInterfaceImplementation simple = new SimpleInterfaceImplementation();
            simple.InterfacesCanContainEventsToo += EventHandler;
            simple.ThisStringPropertyNeedsImplementingToo = "MyString";
            simple.ThisMethodRequiresImplementation();

            ExplicitSimpleInterfaceImplementation expl = new ExplicitSimpleInterfaceImplementation();
            // The following won't work since inteface must be used explicitly for this class instance
            // expl.InterfacesCanContainEventsToo += EventHandler; // ERROR
            // expl.ThisStringPropertyNeedsImplementingToo = "MyString"; // ERROR
            
            // casting works
            (expl as ISimpleInteface).ThisStringPropertyNeedsImplementingToo = "Another MyString";

            // Now, use interface instead of instance class by using a simple cast
            ISimpleInteface iexpl = expl;
            iexpl.InterfacesCanContainEventsToo += EventHandler;
            iexpl.ThisStringPropertyNeedsImplementingToo = "MYstring"; // OK
            iexpl.InterfacesCanContainEventsToo += (s, e) => { Console.WriteLine($"{s.ToString()} This is unnamed lambda. You will have a hard time removing me from outside private scope."); };
            iexpl.ThisMethodRequiresImplementation(); // call handlers in event
            
            iexpl.InterfacesCanContainEventsToo -= null; // fake remove all handlers from inside class scope kind of with iexpl.InterfacesCanContainEventsToo = delegate { };
            iexpl.ThisMethodRequiresImplementation(); // call handlers in event
        }
    }
}