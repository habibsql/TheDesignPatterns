using System;
using System.Collections.Generic;
using System.Text;

namespace ThePattern.Stratigy
{
    public interface IDiscountStratigyProvider
    {
        IDiscountStratigy CreateDiscountStratigy(int couponCode, long productPrice);
    }
}
