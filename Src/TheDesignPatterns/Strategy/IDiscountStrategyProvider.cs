using System;
using System.Collections.Generic;
using System.Text;

namespace ThePattern.Stratigy
{
    public interface IDiscountStrategyProvider
    {
        IDiscountStrategy CreateDiscountStratigy(int couponCode, long productPrice);
    }
}
