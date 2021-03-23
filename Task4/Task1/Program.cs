using System;
using System.Diagnostics;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            CoinChange changer = new CoinChange();
            Stopwatch greedyTime = new Stopwatch();
            greedyTime.Start();
            Console.WriteLine(changer.GreedlyAlgorithm(6, new int[] { 1, 3, 4 }));
            greedyTime.Stop();
            Stopwatch dynamicTime = new Stopwatch();
            dynamicTime.Start();
            Console.WriteLine(changer.DynamicCoinCange(6, new int[] { 1, 3, 4 })); 
            dynamicTime.Stop();
            TimeSpan gt = greedyTime.Elapsed; 
            TimeSpan dt = dynamicTime.Elapsed;
            string grdt = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            gt.Hours, gt.Minutes, gt.Seconds,
            gt.Milliseconds / 10);
            string dynt = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            dt.Hours, dt.Minutes, dt.Seconds,
            dt.Milliseconds / 10);
            Console.WriteLine($"Greedy-{grdt}");//00:00:00.12
            Console.WriteLine($"Dynamic-{dynt}");//00:00:00.0061939
            //result:greedy algorithm time > dynamic algorithm time
        }
    }
}
