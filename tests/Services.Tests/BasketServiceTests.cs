using Domain;
using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class BasketServiceTests
    {
        private IBasketService _basketService;
        
        [SetUp]
        public void SetUp()
        {
            _basketService = new BasketService();
        }
        
        [TestCase("Bread", 1, "1.00")]
        [TestCase("Bread", 2, "2.00")]
        [TestCase("Milk", 1, "1.15")]
        [TestCase("Milk", 2, "2.30")]
        [TestCase("Butter", 1, "0.80")]
        [TestCase("Butter", 2, "1.60")]
        public void ShouldBeAbleToAddOrder(string productName, int quantity, string total)
        {
            var order = new Order(productName, quantity);
            _basketService.AddOrder(order);
            
            Assert.That(_basketService.GetTotal(), Is.EqualTo(decimal.Parse(total)));
        }
    }
}
