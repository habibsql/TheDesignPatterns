using System;
using System.Collections.Generic;
using System.Text;

namespace ThePattern.Stratigy
{
    public class DiscountStratigyProvider : IDiscountStratigyProvider
    {
        public IDiscountStratigy CreateDiscountStratigy(int couponCode, long productPrice)
        {
            IDiscountStratigy stratigy;

            switch (couponCode)
            {
                case (int)CouponCodes.FlatRateCode:
                    stratigy = new FlatRateDiscountStratigy(productPrice);
                    break;
                case (int)CouponCodes.PercentageCode:
                    stratigy = new PercentageDiscountStratigy(productPrice);
                    break;
                case (int)CouponCodes.PercentageLimitCode:
                    stratigy = new PercentageLimitDiscountStratigy(productPrice);
                    break;
                default:
                    throw new ApplicationException($"Sorry! {couponCode} is not a valid Coupon code.");
            }

            return stratigy;
        }
    }
}
