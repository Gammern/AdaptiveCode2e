using System;

namespace ContraVarianceComparer.Model
{
    public class Entity
    {
        public Guid ID { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
