namespace PredicateDecoratorsPattern
{
    /// <summary>
    /// Adapter
    /// </summary>
    class TodayIsAnEvenDayOfTheMonthPredicate : IPredicate
    {
        private readonly DateTester dateTester;

        public TodayIsAnEvenDayOfTheMonthPredicate(DateTester dateTester)
        {
            this.dateTester = dateTester;
        }
        public bool Test()
        {
            return dateTester.TodayIsAnEvenDayOfTheMonth;
        }
    }
}
