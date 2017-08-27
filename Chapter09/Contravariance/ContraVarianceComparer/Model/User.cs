using System;

namespace ContraVarianceComparer.Model
{
    public class User : Entity
    {
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
