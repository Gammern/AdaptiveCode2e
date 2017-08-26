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

        [ContractInvariantMethod]
        private void ClassInvariant()
        {
            Contract.Invariant(this.FlatRate >= 0m, "Flat rate must be positive");
        }


        public override decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            Contract.Ensures(Contract.Result<decimal>() >= 0);

            #region Preconditions
            Contract.Requires<ArgumentOutOfRangeException>(packageWeightInKilograms < 0f);
            if (packageWeightInKilograms < 0f) throw new Exception("Code Contracts Broken");
            Contract.Requires<ArgumentOutOfRangeException>(packageDimensionsInCentimetres?.Depth > 0f &&
                packageDimensionsInCentimetres?.Height > 0f &&
                packageDimensionsInCentimetres?.Width > 0f);
            Contract.Requires<ArgumentNullException>(destination != null);
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
