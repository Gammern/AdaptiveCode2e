namespace DecoratorPattern
{
    internal interface IComponent
    {
        /// <summary>
        /// Function shared by decorator and wrapped class
        /// </summary>
        void DoSomething();
    }
}