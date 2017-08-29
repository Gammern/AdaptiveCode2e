using System;

namespace SubtypeCovariance.Model
{
    public class Entity
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }
    }
}
