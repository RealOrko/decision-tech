using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Discount
    {
        /* Pre-calculus/hashes/indices is required here with "back of house" product listings, this should scale but wont */
        private readonly string _name;
        private readonly int _moduloMatch;
        private readonly decimal _discount;
        private readonly Func<Order, bool> _matchingOrders;
        private readonly Func<Order, bool> _targetOrders;

        public Discount(
            string name,
            Func<Order, bool> matchingOrders, 
            Func<Order, bool> targetOrders,
            int moduloMatch,
            decimal discount)
        {
            _name = name;
            _matchingOrders = matchingOrders;
            _targetOrders = targetOrders;
            _moduloMatch = moduloMatch;
            _discount = discount;
        }

        public List<Order> GetDiscount(List<Order> orders)
        {
            var matchingOrdersFilter = orders.Where(_matchingOrders).ToList();
            var targetOrdersFilter = orders.Where(_targetOrders).Except(matchingOrdersFilter).ToList();

            var totalOrders = matchingOrdersFilter.Sum(x => x.Quantity);
            var targetOrders = targetOrdersFilter.Sum(y => y.Quantity);

            var discountIterations = (totalOrders * (targetOrders + 1)) / _moduloMatch;

            var discountOrders = new List<Order>();
            for (var i = 0; i < discountIterations; i++)
            {
                discountOrders.Add(new Order(new Product(_name, _discount, Currency.GBP), 1));
            }
            
            return discountOrders;
        }
    }
}
