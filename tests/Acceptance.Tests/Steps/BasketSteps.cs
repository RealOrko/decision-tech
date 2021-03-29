using System;
using Acceptance.Tests.Drivers;
using TechTalk.SpecFlow;

namespace Acceptance.Tests.Steps
{
    [Binding]
    public class BasketSteps
    {
        private readonly BasketDriver _driver;

        public BasketSteps(BasketDriver driver)
        {
            _driver = driver;
        }

        /* 1 Purchase Items */
        
        [Given(@"the basket has (\d+) milk")]
        public void GivenMilk(int quantityMilk)
        {
            _driver.NewBasketService().WithProduct();
        }

        [Given(@"the basket has (\d+) butter")]
        public void GivenButter(int quantityButter)
        {
            _driver.NewBasketService().WithProduct();
        }

        [Given(@"the basket has (\d+) bread")]
        public void GivenBread(int quantityBread)
        {
            _driver.NewBasketService().WithProduct();
        }

        /* 2 Purchase Items with Combinations */
        
        [Given(@"the basket has (\d+) butter and (\d+) bread")]
        public void GivenButterBread(int quantityButter, int quantityBread)
        {
            _driver.NewBasketService().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) butter and (\d+) milk")]
        public void GivenButterMilk(int quantityButter, int quantityMilk)
        {
            _driver.NewBasketService().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) bread and (\d+) butter")]
        public void GivenBreadButter(int quantityBread, int quantityButter)
        {
            _driver.NewBasketService().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) bread and (\d+) milk")]
        public void GivenBreadMilk(int quantityBread, int quantityMilk)
        {
            _driver.NewBasketService().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) milk and (\d+) butter")]
        public void GivenMilkButter(int quantityMilk, int quantityButter)
        {
            _driver.NewBasketService().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) milk and (\d+) bread")]
        public void GivenMilkBread(int quantityMilk, int quantityBread)
        {
            _driver.NewBasketService().WithProduct().WithProduct();
        }

        /* 3 Purchase Items with Combinations */

        [Given(@"the basket has (\d+) bread, (\d+) butter and (\d+) milk")]
        public void GivenBreadButterMilk(int quantityBread, int quantityButter, int quantityMilk)
        {
            _driver.NewBasketService().WithProduct().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) bread, (\d+) milk and (\d+) butter")]
        public void GivenBreadMilkButter(int quantityBread, int quantityMilk, int quantityButter)
        {
            _driver.NewBasketService().WithProduct().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) milk, (\d+) butter and (\d+) bread")]
        public void GivenMilkButterBread(int quantityMilk, int quantityButter, int quantityBread)
        {
            _driver.NewBasketService().WithProduct().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) milk, (\d+) bread and (\d+) butter")]
        public void GivenMilkBreadButter(int quantityMilk, int quantityBread, int quantityButter)
        {
            _driver.NewBasketService().WithProduct().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) butter, (\d+) milk and (\d+) bread")]
        public void GivenButterMilkBread(int quantityButter, int quantityMilk, int quantityBread)
        {
            _driver.NewBasketService().WithProduct().WithProduct().WithProduct();
        }

        [Given(@"the basket has (\d+) butter, (\d+) bread and (\d+) milk")]
        public void GivenButterBreadMilk(int quantityButter, int quantityBread, int quantityMilk)
        {
            _driver.NewBasketService().WithProduct().WithProduct().WithProduct();
        }

        /* Total the basket */

        [When(@"I total the basket")]
        public void WhenTotal()
        {
            _driver.GetTotal();
        }

        /* Assertion of total */
        
        [Then(@"the total should be £(\d+\.\d+)")]
        public void ThenTotal(string total)
        {
            _driver.Assert(decimal.Parse(total));
        }
    }
}