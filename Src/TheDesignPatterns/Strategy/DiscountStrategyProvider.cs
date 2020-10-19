using System;

namespace ThePattern.Stratigy
{
    public class DiscountStrategyProvider : IDiscountStrategyProvider
    {
        public IDiscountStrategy CreateDiscountStratigy(int couponCode, long productPrice)
        {
            IDiscountStrategy stratigy;

            switch (couponCode)
            {
                case (int)CouponCodes.FlatRateCode:
                    stratigy = new FlatRateDiscountStratigy(productPrice);
                    break;
                case (int)CouponCodes.PercentageCode:
                    stratigy = new PercentageDiscountStrategy(productPrice);
                    break;
                case (int)CouponCodes.PercentageLimitCode:
                    stratigy = new PercentageLimitDiscountStrategy(productPrice);
                    break;
                default:
                    throw new ApplicationException($"Sorry! {couponCode} is not a valid Coupon code.");
            }

            return stratigy;
        }
    }
}
