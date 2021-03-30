using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class DiscountTests
    {
        [Test]
        public void ShouldDiscountTwoButterAndSingleBreadAtFiftyPercentOff()
        {
            var twoButters = new Order(Product.Butter, 2);
            var oneBread = new Order(Product.Bread, 1);
            var orders = new List<Order>() { twoButters, oneBread };
            
            var discount = new Discount(
                "2 butter, bread 50% off",
                (o) => o.Product.Equals(Product.Butter),
                (o) => o.Product.Equals(Product.Bread), 
                2,
                -0.5m);
            
            Assert.That(
                discount.GetDiscount(orders).Last().Product.Cost, 
                Is.EqualTo(-0.5m));
        }
        
        [Test]
        public void ShouldDiscountThreeMilkAndFourthMilkFree()
        {
            var threeMilk = new Order(Product.Milk, 3);
            var oneMilk = new Order(Product.Milk, 1);
            var orders = new List<Order>() { threeMilk, oneMilk };
            
            var discount = new Discount(
                "3 milk, 4th free",
                (o) => o.Product.Equals(Product.Milk),
                (o) => o.Product.Equals(Product.Milk), 
                4,
                -1.15m);
            
            Assert.That(
                discount.GetDiscount(orders).Last().Product.Cost, 
                Is.EqualTo(-1.15m));
        }
    }
}
