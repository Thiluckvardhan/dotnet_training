using ModelsLib;

namespace ProductSales
{
    //public class DiscountCalculator
    //{
    //    public decimal GetDiscount(string customerType, decimal amount)
    //    {
    //        if (customerType == "Regular")
    //            return amount * 0.05m;
    //        else if (customerType == "Festival")
    //            return amount * 0.10m;
    //        else if (customerType == "Premium")
    //            return amount * 0.20m;
    //        else if (customerType == "50%")
    //            return amount * .5m;
    //        return 0;
    //    }
    //}



    public class ProductRateCalculator
    {
        public decimal CalculatePrice(IDiscountStrategy discountStrategy, decimal amount)
        {
            decimal discount = discountStrategy.GetDiscount;
            return amount - discount;
        }
    }
}
