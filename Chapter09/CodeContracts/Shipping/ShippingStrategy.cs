using System.Globalization;

namespace Shipping
{
    public class ShippingStrategy : IShippingStrategy
    {
        private decimal flatRate;
                
        public ShippingStrategy(decimal flatRate)
        {
            this.flatRate = flatRate;
        }

        protected decimal FlatRate
        {
            get { return flatRate; }
            set { flatRate = value; }
        }

        public virtual decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            var shippingCost = decimal.MinusOne;
            return shippingCost;
        }
    }
}
