using Domain;
using Services;

namespace Acceptance.Tests.Drivers
{
    public class BasketDriver
    {
        private IBasketService _basketService;

        public BasketDriver NewBasketService()
        {
            _basketService = new BasketService();
            return this;
        }

        public BasketDriver WithDiscount(/*Discount discount*/)
        {
            //_basketService.AddDiscount(discount);
            return this;
        }

        public BasketDriver WithOrder(Order order)
        {
            //_basketService.AddProduct(product);
            return this;
        }

        public BasketDriver GetTotal()
        {
            //this.total = _basketService.GetTotal();
            return this;
        }
        
        public void Assert(decimal total)
        {
        }
    }
}