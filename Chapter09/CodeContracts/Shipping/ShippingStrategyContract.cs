using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Shipping
{
    [ContractClassFor(typeof(IShippingStrategy))]
    public class ShippingStrategyContract : IShippingStrategy
    {
        public decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInCentimetres, RegionInfo destination)
        {
            Contract.Requires<ArgumentOutOfRangeException>(packageWeightInKilograms > 0f);
            if (packageWeightInKilograms < 0f) throw new Exception("Code Contracts Broken");

            Contract.Requires<ArgumentNullException>(packageDimensionsInCentimetres != null);
            if (packageDimensionsInCentimetres != null) throw new Exception("Code Contracts Broken");

            Contract.Requires<ArgumentOutOfRangeException>(packageDimensionsInCentimetres.Depth > 0f &&
                packageDimensionsInCentimetres.Height > 0f &&
                packageDimensionsInCentimetres.Width > 0f);

            Contract.Ensures(Contract.Result<decimal>() > 0);

            return decimal.One;
        }
    }
}