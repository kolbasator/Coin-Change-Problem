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
            var firstResult = coinChanger.GreedlyAlgorithm(0, new int[] { 1, 2, 5, 10, 20, 50, 100 });
            var secondResult = coinChanger.GreedlyAlgorithm(3, new int[] { 1, 2, 5, 10, 20, 50, 100 });
            var thirdResult = coinChanger.GreedlyAlgorithm(15,new int[] { 5, 10 });
            var fourthResult = coinChanger.GreedlyAlgorithm(47,new int[] { 5,47 });
            var fifthResult = coinChanger.GreedlyAlgorithm(100,new int[] { 1, 3 });
            var sixthResult = coinChanger.GreedlyAlgorithm(6,new int[] { 1, 3, 4});
            firstResult.Should().Be(string.Empty);
            secondResult.Should().Be("1 * 2,1 * 1");
            thirdResult.Should().Be("1 * 10,1 * 5");
            fourthResult.Should().Be("1 * 47");
            fifthResult.Should().Be("33 * 3,1 * 1"); 
        }
    }
}