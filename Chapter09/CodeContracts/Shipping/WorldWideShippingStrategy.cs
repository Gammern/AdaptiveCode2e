using System.Globalization;
using System.Diagnostics.Contracts;

namespace Shipping
{
    public class WorldWideShippingStrategy : ShippingStrategy
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
            #region Preconditions
            #endregion

            var shippingCost = decimal.One;

            if (destination == RegionInfo.CurrentRegion)
            {
                shippingCost = 0;
            }

            #region Postconditions
            #endregion

            return shippingCost;
        }
    }
}
