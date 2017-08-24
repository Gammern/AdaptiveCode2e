using System;
using Xunit;

namespace Shipping.Tests
{
    public class ShippingStrategyTests
    {
        private readonly ShippingStrategy sut;
        private readonly Size<float> validDimensions = new Size<float>() { Depth = 1, Height = 1, Width = 1 };
        private readonly Size<float> invalidDimensions = new Size<float>() { Depth = 0, Height = -1, Width = 0 };

        public ShippingStrategyTests()
        {
            sut = new ShippingStrategy();
        }

        [Fact]
        public void CalculateShippingCostRequiresPositiveWeight()
        {
            Assert.Throws<ArgumentOutOfRangeException>("packageWeightInKilograms", () => sut.CalculateShippingCost(-1, validDimensions, null ));
        }

        [Fact]
        public void CalculateShippingCostRequiresDimensions()
        {
            Assert.Throws<ArgumentNullException>("packageDimensionsInCentimetres", () => sut.CalculateShippingCost(1, null, null ));
        }

        [Fact]
        public void CalculateShippingCostRequiresValidDimensions()
        {
            Assert.Throws<ArgumentOutOfRangeException>("packageDimensionsInCentimetres", () => sut.CalculateShippingCost(1, invalidDimensions , null));
        }
    }

}
