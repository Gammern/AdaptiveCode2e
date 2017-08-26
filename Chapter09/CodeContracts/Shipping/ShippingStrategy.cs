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
            #endregion

            var shippingCost = decimal.One;

            #region Postconditions
            #endregion

            return shippingCost;
        }
    }
}
