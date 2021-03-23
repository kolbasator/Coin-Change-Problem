using NUnit.Framework;
using Task1;
using FluentAssertions;

namespace TDD
{
    public class CoinChangeProblemTest
    { 
        [Test]
        public void CoinChangeProblemSimpleTest()
        {
            var coinChanger = new CoinChange();
            var firstResult = coinChanger.GreedlyAlgorithm(0);
            var secondResult = coinChanger.GreedlyAlgorithm(3);
            var thirdResult = coinChanger.GreedlyAlgorithm(15);
            var fourthResult = coinChanger.GreedlyAlgorithm(47);
            var fifthResult = coinChanger.GreedlyAlgorithm(100);
            firstResult.Should().Be(string.Empty);
            secondResult.Should().Be("1 * 2,1 * 1");
            thirdResult.Should().Be("1 * 10,1 * 5");
            fourthResult.Should().Be("2 * 20,1 * 5,1 * 2");
            fifthResult.Should().Be("1 * 100");
        }
    }
}