namespace ThePattern.Stratigy
{
    public interface IDiscountStrategyProvider
    {
        IDiscountStrategy CreateDiscountStratigy(int couponCode, long productPrice);
    }
}
