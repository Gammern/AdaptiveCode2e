using System;
using System.Globalization;
using System.Diagnostics.Contracts;

namespace Shipping
{
    public class ShippingStrategy
    {
        private decimal flatRate;
                
        public ShippingStrategy(decimal flatRate)
        {
            this.flatRate = flatRate;
        }

        protected decimal FlatRate
        {
            get { return flatRate; }
            set
            {
                this.flatRate = value;
            }
        }

        [ContractInvariantMethod]
        private void ClassInvariant()
        {
            Contract.Invariant(this.flatRate > 0m, "Flat rate must be positive and non-zero");
        }

        public virtual decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            Contract.Ensures(Contract.Result<decimal>() > 0);

            #region Preconditions
            Contract.Requires<ArgumentOutOfRangeException>(packageWeightInKilograms < 0f);
            if (packageWeightInKilograms < 0f) throw new Exception("Code Contracts Broken");
            Contract.Requires<ArgumentNullException>(packageDimensionsInCentimetres != null);
            if (packageDimensionsInCentimetres != null) throw new Exception("Code Contracts Broken");
            Contract.Requires<ArgumentOutOfRangeException>(packageDimensionsInCentimetres.Depth > 0f &&
                packageDimensionsInCentimetres.Height > 0f &&
                packageDimensionsInCentimetres.Width > 0f);
            #endregion

            var shippingCost = decimal.MinusOne;

            return shippingCost;
        }
    }
}
