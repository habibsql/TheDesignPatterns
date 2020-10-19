using System;

namespace ThePattern.Stratigy
{
    public class PercentageLimitDiscountStrategy : IDiscountStrategy
    {
        private readonly long _price;
        private const long DiscountAmountLimit = 300;
        private const decimal DiscountRateInPercent = 15; //15%

        public PercentageLimitDiscountStrategy(long price)
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
