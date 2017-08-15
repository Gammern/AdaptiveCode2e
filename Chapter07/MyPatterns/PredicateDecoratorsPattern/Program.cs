using System;

namespace PredicateDecoratorsPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var comp = new ConcreteComponent();
            var predicate = new TodayIsAnEvenDayOfTheMonthPredicate(new DateTester());
            var predicatedComp = new PredicatedComponent(comp, predicate);

            comp.Something();
            predicatedComp.Something();
        }
    }
}
