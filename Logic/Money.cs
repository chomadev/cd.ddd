using System;

namespace Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }

        public decimal Amount =>
            OneCentCount * 0.01m +
            TenCentCount * 0.10m +
            QuarterCount * 0.25m +
            OneDollarCount * 1m +
            FiveDollarCount * 5m +
            TwentyDollarCount * 20m;

        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollarCount, int fiveCentCount, int twentyCentCount)
        {
            if (oneCentCount < 0 || tenCentCount < 0 || quarterCount < 0 || oneDollarCount < 0 || fiveCentCount < 0 || twentyCentCount < 0)
                throw new InvalidOperationException();

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveCentCount;
            TwentyDollarCount = twentyCentCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount
            );
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount
            );
        }
        public static Money Assign(Money money)
        {
            return new Money(
                money.OneCentCount,
                money.TenCentCount,
                money.QuarterCount,
                money.OneDollarCount,
                money.FiveDollarCount,
                money.TwentyDollarCount
            );
        }

        public override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount &&
                TenCentCount == other.TenCentCount &&
                QuarterCount == other.QuarterCount &&
                OneDollarCount == other.OneDollarCount &&
                FiveDollarCount == other.FiveDollarCount &&
                TwentyDollarCount == other.TwentyDollarCount;
        }

        public override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * OneCentCount) ^ 123;
                hashCode = (hashCode * TenCentCount) ^ 123;
                hashCode = (hashCode * QuarterCount) ^ 123;
                hashCode = (hashCode * OneDollarCount) ^ 123;
                hashCode = (hashCode * FiveDollarCount) ^ 123;
                hashCode = (hashCode * TwentyDollarCount) ^ 123;
                return hashCode;
            }
        }
    }
}
