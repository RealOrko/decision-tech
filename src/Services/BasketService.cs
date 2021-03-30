using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Services
{
    public interface IBasketService
    {
        void AddOrder(Order order);
        decimal GetTotal();
    }
    
    public class BasketService : IBasketService
    {
        /* Should be repository but is not */
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public decimal GetTotal()
        {
            var discounts =
                Discount.ThreeMilkFourthForFree.GetDiscount(_orders)
                    .Concat(Discount.TwoButterOneBreadFiftyPercentOff.GetDiscount(_orders))
                    .ToList();
            
            return _orders.Concat(discounts)
                .Sum(x => x.Product.Cost * x.Quantity);
        }
    }
}
