using System;

namespace Logic
{
    public sealed class SnackMachine
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }

        public void InsertMoney(Money insertedMoney)
        {
            MoneyInTransaction += insertedMoney;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = new Money(0, 0, 0, 0, 0, 0);
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = new Money(0, 0, 0, 0, 0, 0);
        }
    }
}
