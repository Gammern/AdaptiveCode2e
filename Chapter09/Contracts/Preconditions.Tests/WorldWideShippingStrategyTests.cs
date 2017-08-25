using System;
using System.Globalization;
using Xunit;

namespace Shipping.Tests
{
    /// <summary>
    /// Inherit all test from supertype in order to check pre/post conditions for free.
    /// Inherited CalculateShippingCostResultMustBePositive() will fail because we have
    /// strengthened preconditions.
    /// </summary>
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
            // Will fail, supertype do not check destination
            Assert.Throws<ArgumentNullException>("destination", () => target.CalculateShippingCost(1, validDimensions, null));
        }

        /// <summary>
        /// Same as supercalss except we have to supply a RegionInfo (strengthened precondition)
        /// </summary>
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
    }
}
