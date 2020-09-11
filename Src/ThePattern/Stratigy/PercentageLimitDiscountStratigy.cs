using System;
using System.Collections.Generic;
using System.Text;

namespace ThePattern.Stratigy
{
    public class PercentageLimitDiscountStratigy : IDiscountStratigy
    {
        private readonly long _price;
        private const long DiscountAmountLimit = 300;
        private const decimal DiscountRateInPercent = 15; //15%

        public PercentageLimitDiscountStratigy(long price)
        {
            _price = price;
        }

        public long Discount()
        {
            decimal discountPercent = DiscountRateInPercent / 100;

            long discountValue = Convert.ToInt64(_price * discountPercent);

            if (discountValue > DiscountAmountLimit)
            {
                return DiscountAmountLimit;
            }

            return discountValue;
        }
    }
}
