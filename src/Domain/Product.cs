using System;

namespace Domain
{
    public class Product : IEquatable<Product>
    {
        /* Should be persistent store with table "Products" */
        
        public static readonly Product Milk = new Product("Milk", 1.15m, Currency.GBP);
        public static readonly Product Bread = new Product("Bread", 1.00m, Currency.GBP);
        public static readonly Product Butter = new Product("Butter", 0.80m, Currency.GBP);

        public Product(string name, decimal cost, Currency currency)
        {
            Name = name;
            Cost = cost;
            Currency = currency;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public Currency Currency { get; set; }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Cost == other.Cost && Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Cost, Currency);
        }

        public static bool operator ==(Product left, Product right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Product left, Product right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Cost)}: {Cost}, {nameof(Currency)}: {Currency}";
        }
    }
}
