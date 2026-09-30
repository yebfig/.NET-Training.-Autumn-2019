using System;
using System.Collections.Generic;
using System.Text;

namespace sorting_array
{
    public interface IKeyFunction
    {
        int GetKey(int value);
    }

    public class AbsKey : IKeyFunction
    {
        public int GetKey(int value)
        {
            return Math.Abs(value);
        }
    }

    public class SymbolCountKey : IKeyFunction
    {
        private readonly char Symbol;
        private readonly int Radix;
        private static readonly string availableSymbols = "0123456789ABCDEF";

        public SymbolCountKey(char symbol, int radix)
        {
            symbol = char.ToUpper(symbol);

            if (radix < 2 || radix > availableSymbols.Length)
                throw new ArgumentOutOfRangeException(nameof(radix), $"Radix must be between 2 and {availableSymbols.Length}.");

            if (availableSymbols.IndexOf(symbol) < 0 || availableSymbols.IndexOf(symbol) >= radix)
                throw new ArgumentException($"Symbol '{symbol}' is not valid for radix {radix}.", nameof(symbol));

            Symbol = symbol;
            Radix = radix;
        }

        public int GetKey(int value)
        {
            int n = Math.Abs(value);

            if (n == 0) return Symbol == '0' ? 1 : 0;

            int count = 0;

            while(n>0)
            {
                int remainder = n % this.Radix;

                if (availableSymbols[remainder] == this.Symbol)
                {
                    ++count;
                }

                n/= this.Radix;
            }

            return count;
        }
    }
}
