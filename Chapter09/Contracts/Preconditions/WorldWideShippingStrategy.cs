using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Shipping
{
    public class WorldWideShippingStrategy : ShippingStrategy
    {
        public WorldWideShippingStrategy() 
            : base(decimal.One)
        {
        }

        public override decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
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

            if (destination == null) // strengthen precondition
            {
                throw new ArgumentNullException(nameof(destination), "Destination must be provied");
            }
            #endregion

            var shippingCost = decimal.One;

            if (destination == RegionInfo.CurrentRegion)
            {
                shippingCost = 0;
            }

            return shippingCost;
        }
    }
}
