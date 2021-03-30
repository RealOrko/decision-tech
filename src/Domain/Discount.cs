using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Discount
    {
        /* Pre-calculus/hashes/indices is required here with "back of house" product listings, this should scale but wont */
        
        /* These should be loaded from an external data source */
        public static readonly Discount TwoButterOneBreadFiftyPercentOff = new Discount(
            "2 butter, bread 50% off",
            (o) => o.Product.Equals(Product.Butter),
            2,
            (o) => o.Product.Equals(Product.Bread),
            1,
            -0.5m);
        
        /* These should be loaded from an external data source */
        public static readonly Discount ThreeMilkFourthForFree = new Discount(
            "3 milk, 4th free",
            (o) => o.Product.Equals(Product.Milk),
            3,
            (o) => o.Product.Equals(Product.Milk), 
            4,
            -1.15m);
        
        private readonly string _name;
        private readonly int _eachMatch;
        private readonly int _eachTarget;
        private readonly decimal _discount;
        private readonly Func<Order, bool> _matchingOrders;
        private readonly Func<Order, bool> _targetOrders;

        public Discount(
            string name,
            Func<Order, bool> matchingOrders, 
            int eachMatch,
            Func<Order, bool> targetOrders,
            int eachTarget,
            decimal discount)
        {
            _name = name;
            _matchingOrders = matchingOrders;
            _eachMatch = eachMatch;
            _targetOrders = targetOrders;
            _eachTarget = eachTarget;
            _discount = discount;
        }

        public List<Order> GetDiscount(List<Order> orders)
        {
            var matchingOrdersFilter = orders
                .Where(_matchingOrders)
                .Select(x => x.Quantity)
                .Sum();
            
            var targetOrdersFilter = orders
                .Where(_targetOrders)
                .Select(x => x.Quantity)
                .Sum();

            var discountOrders = new List<Order>();
            for (var eachMatch = 1; eachMatch <= matchingOrdersFilter; eachMatch++)
            {
                for (var eachTarget = 1; eachTarget <= targetOrdersFilter; eachTarget++)
                {
                    if (eachMatch % _eachMatch == 0 && eachTarget % _eachTarget == 0)
                    {
                        discountOrders.Add(new Order(new Product(_name, _discount, Currency.GBP), 1));
                        break;
                    }
                }
            }

            return discountOrders;
        }
    }
}
