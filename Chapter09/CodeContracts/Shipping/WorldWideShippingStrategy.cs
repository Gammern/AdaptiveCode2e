using System.Globalization;

namespace Shipping
{
    public class WorldWideShippingStrategy : ShippingStrategy, IShippingStrategy
    {
        public WorldWideShippingStrategy() 
            : base(decimal.One)
        {
        }

        public new decimal FlatRate
        {
            get { return base.FlatRate; }
            set { base.FlatRate = value; }
        }

        public override decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            var shippingCost = decimal.One;

            if (destination == RegionInfo.CurrentRegion)
            {
                shippingCost = 0;
            }

            return shippingCost;
        }
    }
}
