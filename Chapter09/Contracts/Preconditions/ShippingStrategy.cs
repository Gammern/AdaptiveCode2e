using System;
using System.Globalization;

namespace Shipping
{
    public class ShippingStrategy
    {
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

            return decimal.MinusOne;
        }
    }
}
