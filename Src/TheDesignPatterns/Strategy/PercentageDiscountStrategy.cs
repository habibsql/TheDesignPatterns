using System;

namespace ThePattern.Stratigy
{
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly long _price;
        private const decimal PercentDiscountRate = 15; // 15%

        public PercentageDiscountStrategy(long price)
        {
            _price = price;
        }

        public long Discount()
        {
            decimal percent = PercentDiscountRate / 100;

            return Convert.ToInt64(_price * percent);
        }
    }
}
