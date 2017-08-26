using System;
using System.Globalization;
using Xunit;

namespace Shipping.Tests
{
    public class WorldWideShippingStrategyTests : ShippingStrategyTests
    {
        public WorldWideShippingStrategyTests()
        {
            sut = new WorldWideShippingStrategy();
        }

        [Fact]
        public void ShippingRegionMustBeProvided()
        {
            Assert.Throws<ArgumentNullException>("destination", () => sut.CalculateShippingCost(1, validDimensions, null));
        }

        [Fact]
        public void ShippingRegionMustBeProvidedForSuperType()
        {
            var target = new ShippingStrategy(decimal.One);
            Assert.Throws<ArgumentNullException>("destination", () => target.CalculateShippingCost(1, validDimensions, null));
        }

        [Fact]
        public void CalculateShippingCostResultMustBePositive2()
        {
            Assert.True(sut.CalculateShippingCost(1, validDimensions, RegionInfo.CurrentRegion) > 0);
        }

        [Fact]
        public void ShippingDomesticallyIsFree()
        {
            var actual = sut.CalculateShippingCost(1, validDimensions, RegionInfo.CurrentRegion);
            Assert.Equal(0, actual);
        }

        [Fact]
        public void ShippingFlatRateCannotBeSetToANegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>("FlatRate", () => (sut as WorldWideShippingStrategy).FlatRate = decimal.MinusOne);
        }

        [Fact]
        public void FlatRatePropertySetCantBeZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>("FlatRate", () => (sut as WorldWideShippingStrategy).FlatRate = decimal.Zero);
        }

    }
}
