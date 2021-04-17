using System;

namespace Fido.Core
{
    internal class Loan
    {
        public Loan(uint balance)
        {
            Balance = balance;
        }

        internal uint Balance { get; private set; }

        internal void Pay(uint payment)
        {
            Balance -= Math.Min(Balance, payment);
        }
    }
}
