using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class DiscountTests
    {
        [Test]
        public void ShouldNotDiscountOneBreadButterAndMilk()
        {
            var oneBread = new Order(Product.Bread, 1);
            var oneButter = new Order(Product.Butter, 1);
            var oneMilk = new Order(Product.Milk, 1);
            var orders = new List<Order>() { oneBread, oneButter, oneMilk };

            var discount = Discount.TwoButterOneBreadFiftyPercentOff;
            
            Assert.That(
                discount.GetDiscount(orders).Sum(x => x.Product.Cost), 
                Is.EqualTo(0.0m));
        }
        
        [Test]
        public void ShouldDiscountTwoButterAndSingleBreadAtFiftyPercentOff()
        {
            var twoButters = new Order(Product.Butter, 2);
            var oneBread = new Order(Product.Bread, 1);
            var orders = new List<Order>() { twoButters, oneBread };

            var discount = Discount.TwoButterOneBreadFiftyPercentOff;
            
            Assert.That(
                discount.GetDiscount(orders).Last().Product.Cost, 
                Is.EqualTo(-0.5m));
        }
        
        [Test]
        public void ShouldDiscountTwoButterAndTwoBreadWithOneAtFiftyPercentOff()
        {
            var twoButters = new Order(Product.Butter, 2);
            var twoBread = new Order(Product.Bread, 2);
            var orders = new List<Order>() { twoButters, twoBread };

            var discount = Discount.TwoButterOneBreadFiftyPercentOff;
            
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

            var discount = Discount.ThreeMilkFourthForFree;
            
            Assert.That(
                discount.GetDiscount(orders).Last().Product.Cost, 
                Is.EqualTo(-1.15m));
        }
    }
}
