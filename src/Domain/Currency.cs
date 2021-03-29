using System;

namespace Domain
{
    public class Currency : IEquatable<Currency>
    {
        /* Should be persistent store with table "Currencies" with child table for conversion rates */
        
        public static readonly Currency GBP = new Currency('£'); 
        
        public Currency(char symbol)
        {
            Symbol = symbol;
        }

        public char Symbol { get; set; }
        
        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(Symbol)}: {Symbol}";
        }
    }
}