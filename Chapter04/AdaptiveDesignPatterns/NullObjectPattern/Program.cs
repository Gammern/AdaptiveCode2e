using System;

namespace NullObjectPattern
{
    class Program
    {
        static IUserRepository userRepository = new UserRepository();

        static void Main(string[] args)
        {
            var user = userRepository.GetByID(Guid.NewGuid());
            // without the null object pattern the following would crash
            user.IncrementSessionTicket();

            Console.WriteLine($"The user's name is: {user.Name}");

            Console.ReadKey();
        }
    }
}