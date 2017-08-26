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

        public virtual decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            #region Preconditions
            Contract.Requires(packageWeightInKilograms < 0f);
            if (packageWeightInKilograms < 0f) throw new Exception("Code Contracts Broken");
            Contract.Requires(packageDimensionsInCentimetres != null);
            if (packageDimensionsInCentimetres != null) throw new Exception("Code Contracts Broken");
            Contract.Requires(packageDimensionsInCentimetres.Depth > 0f &&
                packageDimensionsInCentimetres.Height > 0f &&
                packageDimensionsInCentimetres.Width > 0f);
            #endregion

            var shippingCost = decimal.One;

            #region Postconditions
            #endregion

            return shippingCost;
        }
    }
}
