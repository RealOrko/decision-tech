using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class CurrencyTests
    {
        [TestCase('£', '£')]
        [TestCase('$', '$')]
        public void ShouldBeEqual(char leftSymbol, char rightSymbol)
        {
            var leftCurrency = new Currency(leftSymbol);
            var rightCurrency = new Currency(rightSymbol);
            
            Assert.IsTrue(leftCurrency == rightCurrency);
            Assert.IsTrue(leftCurrency.Equals(rightCurrency));
            Assert.That(leftCurrency, Is.EqualTo(rightCurrency));
        }
        
        [TestCase('£', '$')]
        [TestCase('$', '£')]
        public void ShouldNotBeEqual(char leftSymbol, char rightSymbol)
        {
            var leftCurrency = new Currency(leftSymbol);
            var rightCurrency = new Currency(rightSymbol);
            
            Assert.IsTrue(leftCurrency != rightCurrency);
            Assert.IsTrue(!leftCurrency.Equals(rightCurrency));
            Assert.That(leftCurrency, Is.Not.EqualTo(rightCurrency));
        }
    }
}
