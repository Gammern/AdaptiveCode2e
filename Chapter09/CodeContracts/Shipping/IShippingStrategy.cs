using System.Globalization;
using System.Diagnostics.Contracts;

namespace Shipping
{
    [ContractClass(typeof(ShippingStrategyContract))]
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(float packageWeightInKilograms, 
            Size<float> packageDimensionsInCentimetres, 
            RegionInfo destination);
    }
}