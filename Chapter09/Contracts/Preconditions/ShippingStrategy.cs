using System;
using System.Globalization;

namespace Shipping
{
    public class ShippingStrategy
    {
        protected decimal flatRate;
                
        public ShippingStrategy(decimal flatRate)
        {
            FlatRate = flatRate;
        }

        public decimal FlatRate
        {
            get { return flatRate; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(FlatRate), "Flat rate must be positive and non-zero");
                }

                this.flatRate = value;
            }
        }

        public decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            #region Preconditions
            if (packageWeightInKilograms <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(packageWeightInKilograms), "Package weight must be greater than zero");
            }

            if (packageDimensionsInCentimetres == null)
            {
                throw new ArgumentNullException(nameof(packageDimensionsInCentimetres), "Package dimensions are missing");
            }

            if (packageDimensionsInCentimetres.Height <= 0 || packageDimensionsInCentimetres.Width <= 0 || packageDimensionsInCentimetres.Depth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(packageDimensionsInCentimetres), "Package dimensions must positive and nonzero");
            }
            #endregion

            var shippingCost = decimal.One;

            #region Postconditions
            if (shippingCost <= decimal.Zero)
            {
                throw new ArgumentOutOfRangeException("return", "Shipping cost can't be negative");
            }
            #endregion

            return shippingCost;
        }
    }
}
