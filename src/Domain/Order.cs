﻿namespace Domain
{
    public class Order
    {
<<<<<<< HEAD
        public static readonly Order NoOp = new Order(Domain.Product.Null, 0);
        
=======
>>>>>>> e79583f61fddbc71b409ec5693639019e1fda04e
        /* Should include user profile but does not */
        
        public Order(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{nameof(Product)}: {Product}, {nameof(Quantity)}: {Quantity}";
        }
    }
}
