using System.Globalization;
using System.Diagnostics.Contracts;
using System;

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
            Contract.Requires(packageWeightInKilograms < 0f);
            if (packageWeightInKilograms < 0f) throw new Exception("Code Contracts Broken");
            Contract.Requires(packageDimensionsInCentimetres?.Depth > 0f &&
                packageDimensionsInCentimetres?.Height > 0f &&
                packageDimensionsInCentimetres?.Width > 0f);
            Contract.Requires(destination != null);
            if (destination != null) throw new Exception("Code Contracts Broken");

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
