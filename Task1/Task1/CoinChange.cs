using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    public class CoinChange
    {
        public string GreedlyAlgorithm(int x)
        {
            int[] nominals = new int[] { 1, 2, 5, 10, 20, 50, 100 };
            if (x == 0)
                return string.Empty;
            List<int> result = new List<int>();
            string resultString = string.Empty;
            for (int i = nominals.Length - 1; i >= 0; i--)
            {
                while (x >= nominals[i])
                {
                    x -= nominals[i];
                    result.Add(nominals[i]);
                }
            }
            for (int i = nominals.Length - 1; i >= 0; i--)
            {
                if (result.Contains(nominals[i]))
                {
                    resultString += $"{result.Where(x => x == nominals[i]).Count()} * {nominals[i]},";
                }
            }
            return resultString.Remove(resultString.Length - 1); ;
        }
    }
}
