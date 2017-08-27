using System.Collections.Generic;

namespace ContraVarianceComparer.Model
{
    public class EntityEqualityComparer: IEqualityComparer<Entity>
    {
        public bool Equals(Entity left, Entity right)
        {
            return left.ID == right.ID;
        }

        public int GetHashCode(Entity obj)
        {
            return obj.GetHashCode();
        }
    }
}
