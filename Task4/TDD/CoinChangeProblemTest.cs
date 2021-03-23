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
            var firstResult = coinChanger.DynamicCoinCange(6,new int[] { 1, 3, 4}); 
            var secondResult = coinChanger.DynamicCoinCange(12,new int[] { 1, 6, 8}); 
            var thirdResult = coinChanger.DynamicCoinCange(48,new int[] { 1, 16, 40}); 
            var fourthResult = coinChanger.DynamicCoinCange(50,new int[] { 5, 25, 40}); 
            var fifthResult = coinChanger.DynamicCoinCange(500,new int[] { 10, 250, 480}); 
            firstResult.Should().Be("2 * 3");
            secondResult.Should().Be("2 * 6");
            thirdResult.Should().Be("3 * 16");
            fourthResult.Should().Be("2 * 25");
            fifthResult.Should().Be("2 * 250");
        }
    }
}