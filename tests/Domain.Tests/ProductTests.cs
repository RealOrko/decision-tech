using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [TestCase("a", "1.0", '£', "a", "1.0", '£')]
        [TestCase("b", "1.2", '£', "b", "1.2", '£')]
        [TestCase("c", "2.1", '$', "c", "2.1", '$')]
        [TestCase("d", "3.0", '$', "d", "3.0", '$')]
        public void ShouldBeEqual(string leftName, string leftPrice, char leftCurrency, string rightName, string rightPrice, char rightCurrency)
        {
            var leftProduct = new Product(leftName, decimal.Parse(leftPrice), new Currency(leftCurrency));
            var rightProduct = new Product(rightName, decimal.Parse(rightPrice), new Currency(rightCurrency));
            
            Assert.IsTrue(leftProduct == rightProduct);
            Assert.IsTrue(leftProduct.Equals(rightProduct));
            Assert.That(leftProduct, Is.EqualTo(rightProduct));
        }
        
        [TestCase("a", "1.0", '£', "b", "1.0", '£')]
        [TestCase("b", "1.2", '£', "b", "1.3", '£')]
        [TestCase("c", "2.1", '£', "c", "2.1", '$')]
        [TestCase("d", "3.0", '$', "d", "3.0", '£')]
        public void ShouldNotBeEqual(string leftName, string leftPrice, char leftCurrency, string rightName, string rightPrice, char rightCurrency)
        {
            var leftProduct = new Product(leftName, decimal.Parse(leftPrice), new Currency(leftCurrency));
            var rightProduct = new Product(rightName, decimal.Parse(rightPrice), new Currency(rightCurrency));
            
            Assert.IsTrue(leftProduct != rightProduct);
            Assert.IsTrue(!leftProduct.Equals(rightProduct));
            Assert.That(leftProduct, Is.Not.EqualTo(rightProduct));
        }
    }
}
