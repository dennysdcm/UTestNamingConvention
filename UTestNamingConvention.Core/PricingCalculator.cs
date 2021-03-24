using System;

namespace UTestNamingConvention.Core
{
    public class PricingCalculator
    {
        public const decimal PreferredCustomerDiscount = 0.2m;

        public decimal Calculate(int units, Customer customer, decimal unitPrice)
        {
            if (units < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(units), "Units must be zero or greater");
            }

            var price = units * unitPrice;
            
            if(customer.IsPreferred)
            {
                return price * (1 - PreferredCustomerDiscount);
            }            

            return price;
        }
    }
}
