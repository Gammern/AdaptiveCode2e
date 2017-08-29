using System;

namespace ContraVarianceComparer
{
    using Model;
    using System.Collections.Generic;

    class Program
    {
        static User user1 = new User();
        static User user2 = new User();

        static void Main(string[] args)
        {
            // More specific = less specific type
            IEqualityComparer<User> entityComparer = new EntityEqualityComparer();
            var areEqual = entityComparer.Equals(user1, user2);
            Console.WriteLine($"user1 {(areEqual ? "==" : "!=")} user2");
            var user1ref = user1;
            areEqual = entityComparer.Equals(user1ref, user1);
            Console.WriteLine($"user1ref {(areEqual ? "==" : "!=")} user1");
            Entity entity1ref = user1;
            // Downcast
            areEqual = (entityComparer as IEqualityComparer<Entity>).Equals(entity1ref, user1);
            Console.WriteLine($"entity1ref {(areEqual ? "==" : "!=")} user1");
        }
    }
}
