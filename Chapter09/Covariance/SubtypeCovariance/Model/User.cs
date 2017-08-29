using System;

namespace SubtypeCovariance.Model
{
    public class User : Entity
    {
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
