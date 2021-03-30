using FluentAssertions;
using Logic;
using System;
using Xunit;

namespace TestProject
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var sum = money1 + money2;

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }

        [Fact]
        public void Subtract_of_two_moneys_produces_correct_result()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var sum = money1 - money2;

            sum.OneCentCount.Should().Be(0);
            sum.TenCentCount.Should().Be(0);
            sum.QuarterCount.Should().Be(0);
            sum.OneDollarCount.Should().Be(0);
            sum.FiveDollarCount.Should().Be(0);
            sum.TwentyDollarCount.Should().Be(0);
        }

        [Fact]
        public void Two_money_instances_equal_if_contain_same_amount()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_contain_different_amount()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(10, 2, 3, 4, 5, 6);

            money1.Should().NotBe(money2);
            money1.GetHashCode().Should().NotBe(money2.GetHashCode());
        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -1, 0, 0, 0, 0)]
        [InlineData(0, 0, -1, 0, 0, 0)]
        [InlineData(0, 0, 0, -1, 0, 0)]
        [InlineData(0, 0, 0, 0, -1, 0)]
        [InlineData(0, 0, 0, 0, 0, -1)]
        public void Cannot_create_money_with_negative_value(
            int oneCentCount, int tenCentCount, int quarterCount,
            int oneDollarCount, int fiveDolarCount, int twentyDollarCount)
        {
            Action action = () => new Money(
                oneCentCount, tenCentCount, quarterCount,
                oneDollarCount, fiveDolarCount, twentyDollarCount);

            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, 0, .01)]
        [InlineData(0, 1, 0, 0, 0, 0, .10)]
        [InlineData(0, 0, 1, 0, 0, 0, .25)]
        [InlineData(0, 0, 0, 1, 0, 0, 1)]
        [InlineData(0, 0, 0, 0, 1, 0, 5)]
        [InlineData(0, 0, 0, 0, 0, 1, 20)]
        public void Amount_is_calculated_correctly(
            int oneCentCount, int tenCentCount, int quarterCount,
            int oneDollarCount, int fiveDolarCount, int twentyDollarCount,
            decimal expected)
        {
            var money = new Money(
                oneCentCount, tenCentCount, quarterCount,
                oneDollarCount, fiveDolarCount, twentyDollarCount);

            money.Amount.Should().Be(expected);
        }

        [Fact]
        public void Cannot_subtract_more_than_exists()
        {
            var money1 = new Money(1, 0, 0, 0, 0, 0);
            var money2 = new Money(0, 1, 0, 0, 0, 0);

            Action action = () =>
            {
                Money money = money1 - money2;
            };
            action.Should().Throw<InvalidOperationException>();
        }
    }
}
