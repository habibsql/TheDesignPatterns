using System;
using System.Collections.Generic;
using System.Text;

namespace ThePattern.Stratigy
{
    public class PercentageDiscountStratigy : IDiscountStratigy
    {
        private readonly long _price;
        private const decimal PercentDiscountRate = 15; // 15%

        public PercentageDiscountStratigy(long price)
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
