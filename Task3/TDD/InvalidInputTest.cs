using NUnit.Framework;
using Task1;
using System;
using FluentAssertions;

namespace TDD
{
    public class InvalidInputTest
    {
        [Test]
        public void InvalidInputSimpleTest()
        {
            var coinChanger = new CoinChange();
            Action negativeInteger = () => coinChanger.DynamicCoinCange(-6, new int[] { 1, 3, 4 });
            Action negativeCoin = () => coinChanger.DynamicCoinCange(12, new int[] { 1, -6, 8 });
            Action notUniqueCoins = () => coinChanger.DynamicCoinCange(48, new int[] { 1, 16, 40,40 });
            var nullIntegerValueResult = coinChanger.DynamicCoinCange(0, new int[] { 5, 25, 40 });
            negativeCoin.Should().Throw<Exception>()
                .WithMessage("Coin should be positive integer");
            negativeInteger.Should().Throw<Exception>()
               .WithMessage("Input should be a positive integer");
            notUniqueCoins.Should().Throw<Exception>()
               .WithMessage("Coins should have unique values");
            nullIntegerValueResult.Should().Be(string.Empty);
        }
    }
}