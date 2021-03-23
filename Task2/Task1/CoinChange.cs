using System;
using System.Text.RegularExpressions; 
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    public class CoinChange
    {
        public string GreedlyAlgorithm(int x, int[] nominals)
        {
            for (int p = 0; p < nominals.Length; p++)
            {
                var nominalMatchCount = nominals.Where(x => x == nominals[p]).Count();
                if (nominalMatchCount != 1)
                    throw new Exception("Coins should have uniquevalues");
                else if (nominals[p] < 0)
                    throw new Exception("Coin should be positive integer");
            }
            if (x < 0)
            {
                throw new Exception("Input should be a positive integer");
            }
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
                    resultString += $"{result.Where(x => x == nominals[i]).Count()} * {nominals[i]},";
            }
            return resultString.Remove(resultString.Length - 1); ;
        }
    }
}
