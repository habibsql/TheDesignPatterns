using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ThePattern.Stratigy
{
    public class DiscountStartigyTests
    {
        private FlatRateDiscountStratigy flatRateDiscountStratigy;
        private PercentageDiscountStratigy percentageDiscountStratigy;
        private PercentageLimitDiscountStratigy percentageLimitDiscountStratigy;

        public DiscountStartigyTests()
        {
        }

        [Fact]
        public void ShouldDiscountFixedAmount()
        {
            long price = 1000;

            flatRateDiscountStratigy = new FlatRateDiscountStratigy(price);

            long discount = flatRateDiscountStratigy.Discount();

            Assert.Equal(700, discount);
        }

        [Fact]
        public void ShouldDiscountPercentage()
        {
            long price = 1000;

            percentageDiscountStratigy = new PercentageDiscountStratigy(price);

            long discount = percentageDiscountStratigy.Discount();

            Assert.Equal(150, discount);
        }

        [Fact]
        public void ShouldDiscountPercentageLimitPolicy()
        {
            long price = 1800;

            percentageLimitDiscountStratigy = new PercentageLimitDiscountStratigy(price);

            long discount = percentageLimitDiscountStratigy.Discount();

            Assert.Equal(270, discount);
        }

        [Fact]
        public void ShouldDiscountMaxRateWithIgnoringActualCalculatedDiscount()
        {
            long price = 3000;

            percentageLimitDiscountStratigy = new PercentageLimitDiscountStratigy(price);

            long discount = percentageLimitDiscountStratigy.Discount();

            Assert.Equal(300, discount);
        }

    }
}
